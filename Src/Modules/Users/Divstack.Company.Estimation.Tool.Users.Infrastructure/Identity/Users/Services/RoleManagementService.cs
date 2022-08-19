namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Identity.Users.Services;

using System;
using System.Threading.Tasks;
using Application.Authentication;
using Domain.Users;
using Microsoft.AspNetCore.Identity;

public class RoleManagementService : IRoleManagementService
{
    private readonly RoleManager<ApplicationRole> roleManager;

    public RoleManagementService(RoleManager<ApplicationRole> roleManager)
    {
        this.roleManager = roleManager;
    }

    public async Task AddNewRole(string roleName)
    {
        if (await roleManager.RoleExistsAsync(roleName))
        {
            throw new InvalidOperationException($"Role [{roleName}] already exists.");
        }

        var result = await roleManager.CreateAsync(new ApplicationRole
        {
            Name = roleName
        });
        if (result.Succeeded == false)
        {
            throw new NotImplementedException(); // todo
        }
    }

    public async Task<bool> RoleExists(string roleName)
    {
        return await roleManager.RoleExistsAsync(roleName);
    }
}
