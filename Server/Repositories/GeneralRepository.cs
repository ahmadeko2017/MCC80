﻿using ClientServer.Contracts;
using ClientServer.Data;

namespace ClientServer.Repositories;

public class GeneralRepository<TEntity> : IGeneralRepository<TEntity> where TEntity : class
{
    protected readonly BookingDbContext _context;

    protected GeneralRepository(BookingDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    /// <inheritdoc />
    public TEntity? GetByGuid(Guid guid)
    {
        var entity = _context.Set<TEntity>().Find(guid);
        _context.ChangeTracker.Clear();
        return entity;
    }

    /// <inheritdoc />
    public TEntity? Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges(); // Untuk melakukan execute di querry biasa
            return entity; // Return entity untuk meyimpan data yang di set
        }
        catch
        {
            return null;
        }
    }

    /// <inheritdoc />
    public bool Update(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc />
    public bool Delete(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc />
    public bool IsExist(Guid guid)
    {
        return GetByGuid(guid) is not null;
    }
    
    public void Clear()
    {
        _context.ChangeTracker.Clear();
    }
}