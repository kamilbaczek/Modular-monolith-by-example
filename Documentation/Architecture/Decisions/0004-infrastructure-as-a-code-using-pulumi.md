# 4. Infrastructure as a code using pulumi

Date: 2022-09-16

## Status

Accepted

## Context

Application is using Azure Services and we had issue with menagming infrastructure via azure admin panel.

It was hard to track changes and it was hard to reproduce infrastructure in case of disaster.
It was also hard to share knowledge about infrastructure between team members.
It was hard to add new components or feature flags to all environments.

## Decision

We choose to use pulumi to manage infrastructure as a code.
Pulumi is a tool that allows you to declare infrastructure using general purpose programming languages. 
We can manage infrastructure in C# language. Team knows well C# and it is easy to mantain and test infrastructure code.
Pulumi gives cli tools, admin panel, secrets management and many more.

## Consequences
Pulumi is paid tool. We have to pay for using pulumi.