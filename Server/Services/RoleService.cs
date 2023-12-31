﻿using ClientServer.Contracts;
using ClientServer.DTOs.Roles;
using ClientServer.DTOs.Universities;
using ClientServer.Models;

namespace ClientServer.Services;

public class RoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public IEnumerable<RoleDto> GetAll()
    {
        var roles = _roleRepository.GetAll();
        if (!roles.Any())
        {
            return Enumerable.Empty<RoleDto>();
        }

        var roleDtos = new List<RoleDto>();
        foreach (var role in roles)
        {
            roleDtos.Add((RoleDto)role);
        }

        return roleDtos;
    }

    public RoleDto? GetByGuid(Guid guid)
    {
        var role = _roleRepository.GetByGuid(guid);
        if (role is null)
        {
            return null;
        }

        return (RoleDto)role;
    }

    public NewRoleDto? Create(NewRoleDto newRoleDto)
    {
        var role = _roleRepository.Create(newRoleDto);
        if (role is null)
        {
            return null;
        }

        return (NewRoleDto)role;
    }

    public int Update(RoleDto roleDto)
    {
        var role = _roleRepository.GetByGuid(roleDto.Guid);
        if (role is null)
        {
            return -1;
        }

        Role toUpdate = roleDto;
        toUpdate.CreatedDate = role.CreatedDate;
        var result = _roleRepository.Update(toUpdate);

        return result ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var role = _roleRepository.GetByGuid(guid);
        if (role is null)
        {
            return -1;
        }

        var result = _roleRepository.Delete(role);
        return result ? 1 : 0;
    }
}