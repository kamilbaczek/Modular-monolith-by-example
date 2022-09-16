namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System;
using System.Threading.Tasks;
using Application.Authentication;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

internal sealed class RoleManagementService : IRoleManagementService
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RoleManagementService(RoleManager<ApplicationRole> roleManager) => _roleManager = roleManager;

    public async Task AddNewRole(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            throw new InvalidOperationException($"Role [{roleName}] already exists.");
        }

        var result = await _roleManager.CreateAsync(new ApplicationRole
        {
            Name = roleName
        });
        if (result.Succeeded == false)
        {
            throw new NotImplementedException(); // todo
        }
    }

    public async Task<bool> RoleExists(string roleName) => await _roleManager.RoleExistsAsync(roleName);
}
