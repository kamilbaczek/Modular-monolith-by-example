# 2. Infrastructure_migration_to_Azure

Date: 2022-03-31

## Status

Accepted

## Context

Estimation Tool has advanced infrastructure like logging, observability, configuration, feature flags and etc.
Estimation Tool now uses few platforms like sentry, heroku etc. Platforms have diffrent vendors. They are hard to mantain and integrate with other.
Infrastructure have to be unified.
Options:
- Use Azure
- Use AWS
- Use Other Cloud Provider

## Decision

Decision is to use Azure because that platform is created by Microsoft like .Net. In result it easy to configure and has tools integrated with .NET. 
Next important thing is that team is experienced with Azure. This is the best option for now for this project.

## Consequences
Consequence can be vendor look and dependency with one platform. If in the future Azure will be more expensive or down. This can have huge impact on project.