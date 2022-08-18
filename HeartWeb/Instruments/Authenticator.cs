﻿using HeartWeb.Data;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HeartWeb.Instruments;

public static class Authenticator
{
    public static bool Check(ISession session, ApplicationDbContext context, ViewDataDictionary dictionary)
    {
        string? login = session.GetString("login");
        string? hash = session.GetString("hash");
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(hash))
        {
            return false;
        }
        User? foundUser = context.Users.FirstOrDefault(x=>x.Login.Equals(login) && x.Password.Equals(hash));
        if (foundUser == null)
        {
            return false;
        }
        dictionary["login"] = foundUser.Login;
        dictionary["name"] = $"{foundUser.Name} {foundUser.Surname}";
        dictionary["admin"] = foundUser.Admin.ToString().ToLower();
        return true;
    }

    public static bool? CheckAdmin(ISession session, ApplicationDbContext context, ViewDataDictionary dictionary)
    {
        string? login = session.GetString("login");
        string? hash = session.GetString("hash");
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(hash))
        {
            return false;
        }
        User? foundUser = context.Users.FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(hash));
        if (foundUser == null)
        {
            return false;
        }
        dictionary["login"] = foundUser.Login;
        dictionary["name"] = $"{foundUser.Name} {foundUser.Surname}";
        dictionary["admin"] = foundUser.Admin.ToString().ToLower();
        if (!foundUser.Admin)
        {
            return null;
        }
        return true;
    }

    public static string GetLogin(ViewDataDictionary dictionary) => (dictionary["login"] ?? "").ToString();

    public static async Task<bool> Register(ApplicationDbContext context, RegisterModel model)
    {
        model.Login = model.Login.ToLower();
        User? foundUser = context.Users.FirstOrDefault(x=>x.Login.ToLower().Equals(model.Login));
        if (foundUser != null)
        {
            return false;
        }
        User user = new User()
        {
            Login = model.Login,
            Password = Hasher.ComputeHash(model.Login, model.Password),
            Name = model.Name,
            Surname = model.Surname,
            Phone = model.Phone,
            Region = model.Region,
            IsFromCity = model.IsFromCity == 1,
            Admin = false
        };
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return true;
    }

    public static bool Login(ISession session, ApplicationDbContext context, string login, string password)
    {
        login = login.ToLower();
        password = Hasher.ComputeHash(login,password);
        User? foundUser = context.Users.FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));
        if (foundUser == null)
        {
            return false;
        }
        session.SetString("login", login);
        session.SetString("hash", password);
        return true;
    }

    public static void Logout(ISession session)
    {
        session.Clear();
    }
}