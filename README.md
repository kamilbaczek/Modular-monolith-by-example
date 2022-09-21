# Estimations Tool - makes estimations easier

## Table of contents
* [Presentation](#presentation)
* [Documentation](#documentation)
  * [Event Storming](#event-storming)
* [Technologies](#technologies)
* [CI/CD](#ci/cd)
* [Test Environment](#test-environment)

## Presentation
[![Presentation](https://i3.ytimg.com/vi/-FaXMV2-k64/maxresdefault.jpg)](https://www.youtube.com/watch?v=-FaXMV2-k64&t=11s&ab_channel=ArtOfSoftwareDesign)

## Technologies
#### Dotnet Version: 6.0.1
![.Net 6](https://user-images.githubusercontent.com/74410956/143401887-afbef644-f5ce-4d2b-aee1-09e0457d74eb.png)
![Heroku](https://user-images.githubusercontent.com/74410956/143401316-4a69eb67-c2eb-41d1-ab5c-751a9c79235c.png)
![Docker](https://user-images.githubusercontent.com/74410956/143401493-8f41000d-0d82-4005-b643-75d6045394c2.png)
![Sentry](https://user-images.githubusercontent.com/74410956/144380180-42e47963-1793-4be5-9a72-47da2620fdce.png)

### Integrations
![trello](https://user-images.githubusercontent.com/74410956/144380471-279a4d7f-02cb-48c8-aa10-3221d8b65a31.png)     
![stripe](https://user-images.githubusercontent.com/74410956/144380424-f664291b-ef58-42f3-8f6d-ca75267652ad.png)

### CI/CD
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=kamilbaczek_Estimation-Tool&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=kamilbaczek_Estimation-Tool)
##### Domain Code Coverage
[![Domain Code Coverage](https://codecov.io/gh/kamilbaczek/Estimation-Tool/branch/develop/graph/badge.svg?token=S66MBBE6CV)](https://codecov.io/gh/kamilbaczek/Estimation-Tool)

#### ![server](https://user-images.githubusercontent.com/74410956/144381496-43427b48-909b-4b63-b4b2-687f90d2bce6.png) 

[Application](https://estimation-tool-api.azurewebsites.net)     
#### ![server](https://user-images.githubusercontent.com/74410956/144381496-43427b48-909b-4b63-b4b2-687f90d2bce6.png) 

[Swagger](https://estimation-tool-api.azurewebsites.net/index.html)

## Documentation
### C4
#### System Context
![image](https://github.com/kamilbaczek/Estimation-Tool/blob/develop/Documentation/C4/system_context_diagram.svg)

#### Cloud Infrastructure
![image](https://github.com/kamilbaczek/Estimation-Tool/blob/develop/Documentation/C4/containers_diagram.svg)


#### Event Storming
[Miro](https://miro.com/app/board/o9J_lcC1E7g=/?invite_link_id=913994717613)

##### Priorities
<img width="934" alt="image" src="https://user-images.githubusercontent.com/74410956/159788894-a9a3c640-b6da-4f45-8363-9e4877abfdba.png">

##### Valuations Flow
![diagram](https://user-images.githubusercontent.com/74410956/142997315-97c09d1f-cef3-416f-98bf-069b388ea019.png)

## Notes for developers
### Dotnet format as precommit hook
Author cares about code quality of this projected. That why dotnet format is executed before each commit. To make code properly formatted always. This save a lot of time during code review. Rules for dotnet format are stored in .editorconfig file. Install [precommit](https://pre-commit.com/) before you will start commit even locally.


