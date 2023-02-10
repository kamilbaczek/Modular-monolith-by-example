# 4. Infrastructure as a code using pulumi

Date: 2022-09-16

## Status

Accepted

## Context
The team identified the following issues with the existing method of managing infrastructure via the Azure Admin Panel:
- Difficulty in tracking changes
- Difficulty in reproducing infrastructure in case of disaster
- Difficulty in sharing knowledge about infrastructure among team members
- Difficulty in adding new components or feature flags to all environments

## Decision

To address these issues, the team decided to adopt Pulumi as the IAC tool. Pulumi allows declaring infrastructure using general-purpose programming languages, and the team chose to use C#, which they are familiar with and easy to maintain and test. Pulumi provides various tools such as CLI tools, admin panel, secrets management, and more.

## Consequences
### Advantages
- Improved infrastructure management: Pulumi provides a more efficient and automated way of managing infrastructure, making it easier to track changes, reproduce infrastructure, and share knowledge among team members.

- Better version control: By storing infrastructure code in a code repository, it becomes easier to manage different versions of infrastructure and collaborate with others.

- Increased transparency: The use of Pulumi provides a clear and transparent view of the entire infrastructure, making it easier to understand and manage.

- Improved consistency: Pulumi provides a consistent approach to managing infrastructure across different environments, reducing the likelihood of configuration drift and human error.

- Faster deployment: Pulumi allows for faster deployment of infrastructure by automating manual tasks and reducing the time required for manual configuration.

- Enhanced security: Pulumi provides built-in secrets management, which helps secure sensitive information and reduces the risk of accidental exposure.

### Drawbacks
- Learning curve: Pulumi requires a certain level of technical skill and understanding of programming concepts, which can be a barrier for some users.

- Compatibility: Pulumi may not be compatible with all cloud platforms, and may require significant customization to support specific platforms or services.

- Integration challenges: Integrating Pulumi with existing tools and processes may require significant effort and may not always be straightforward.

- Limited community support: As a relatively new tool, Pulumi may not have a large community of users or a robust ecosystem of third-party tools and plugins.

- Cost: Pulumi is a paid tool and may require a significant investment, especially for large-scale deployments.

- Maintenance overhead: While Pulumi automates many tasks, it still requires ongoing maintenance and monitoring to ensure that infrastructure is functioning as expected.
