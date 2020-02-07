# Mossad HR application

## How to test

### Setting connection string

Please set the **database path** in the app.config connection string in **WinService** and **Tests\IntegrationTests** projects to an appropriate path.

### Creating database

Tests/IntegrationTests project contains a test called **CreateDb** which **creates the database** and adds test data to it.

## Implementation details

The BE solution uses Nancy FX a mature, well supported, lightweight framework for WEB API. See https://auth0.com/blog/meet-nancy-a-lightweight-web-framework-for-dot-net/

The solution is multi layered, so it is easy to convert ASP.NET WEB API if necessary.

This solution is based on my earlier hobby work.

## Known issues

1. The database is not optimized for speed. More indexes should be defined.
2. Recruiter password handling is not implemented
3. Recruiter security token handling is not implemented
4. When a candidate is accepted/rejected the candidate is marked to be seen by the recruiter. This is represented by a many-to-many relationship. However the recruiter side of the relationship seems to have issues. This may be a problem with the code first database generation of Entity Framework.

## Task Description

Original task description moved to **Doc** folder
