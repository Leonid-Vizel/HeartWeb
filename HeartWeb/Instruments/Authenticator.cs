using HeartWeb.Data;
using HeartWeb.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace HeartWeb.Instruments;

public static class Authenticator
{
    public static bool Check(ISession session, ViewDataDictionary dictionary)
    {
        string? login = session.GetString("login");
        if (string.IsNullOrEmpty(login))
        {
            return false;
        }
        dictionary["login"] = login;
        dictionary["name"] = session.GetString("name");
        dictionary["id"] = session.GetInt32("id");
        dictionary["admin"] = session.GetBoolean("admin") ?? false;
        return true;
    }

    public static bool? CheckAdmin(ISession session, ViewDataDictionary dictionary)
    {
        string? login = session.GetString("login");
        if (string.IsNullOrEmpty(login))
        {
            return false;
        }
        dictionary["login"] = login;
        dictionary["name"] = session.GetString("name");
        dictionary["id"] = session.GetInt32("id");
        bool admin = session.GetBoolean("admin") ?? false;
        dictionary["admin"] = admin;
        if (!admin)
        {
            return null;
        }
        return true;
    }

    public static string GetLogin(ViewDataDictionary dictionary) => (dictionary["login"]?.ToString() ?? "").ToLower();
    public static int GetId(ViewDataDictionary dictionary) => (dictionary["id"] as int?) ?? 0;
    public static async Task<bool> Register(ApplicationDbContext context, RegisterModel model, CancellationToken token = default)
    {
        model.Login = model.Login.ToLower();
        User? foundUser = await context.Users.FirstOrDefaultAsync(x=>x.Login.ToLower().Equals(model.Login), token);
        if (foundUser != null)
        {
            return false;
        }
        await context.Users.AddAsync(model.ToUser(), token);
        await context.SaveChangesAsync(token);
        return true;
    }
    public static async Task<bool> Login(ISession session, ApplicationDbContext context, AuthModel model, CancellationToken token = default)
    {
        model.Login = model.Login.ToLower();
        model.Password = Hasher.ComputeHash(model.Login, model.Password);
        User? foundUser = await context.Users.FirstOrDefaultAsync(x => x.Login.Equals(model.Login) && x.Password.Equals(model.Password), token);
        if (foundUser == null)
        {
            return false;
        }
        session.SetString("login", model.Login);
        session.SetString("name", foundUser.Name);
        session.SetBoolean("admin", foundUser.Admin);
        session.SetInt32("id", foundUser.Id);
        return true;
    }
    public static void Logout(ISession session) => session.Clear();
}