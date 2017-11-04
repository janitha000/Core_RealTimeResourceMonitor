using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

public class CachedUserManager : IManager<User>
{
    private readonly IMemoryCache _cache;
    private readonly UsersManager _userManager;
    private static readonly string _userKey = "firstName";
    private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

    public CachedUserManager(IMemoryCache cache, UsersManager userManager)
    {
        _cache = cache;
        _userManager = userManager;
    }

    public User Add(User data)
    {
        throw new System.NotImplementedException();
    }

    public bool Exists(string param)
    {
        throw new System.NotImplementedException();
    }

    public User Get(string param)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<User> GetAll()
    {
        return _cache.GetOrCreate(_userKey, entry =>
       {
           entry.SlidingExpiration =
           _defaultCacheDuration;
           return _userManager.GetAll();
       });
    }

    public User Update(User Data)
    {
        throw new System.NotImplementedException();
    }
}