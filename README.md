# How to test

## Setting connection string

Please set the **database path** in the app.config connection string in **WinService** and **Tests\IntegrationTests** projects to an appropriate path.

## Creating database

IntegrationTests contain a test called CreateDb which **creates the database** and adds test data to it.

## Implementation details

The BE solution uses Nancy FX a mature, well supported, lightweight framework for WEB API. See https://auth0.com/blog/meet-nancy-a-lightweight-web-framework-for-dot-net/

The solution is multi layered, so it is easy to convert ASP.NET MVC if necessary.

This solution is based on my earlier hobby work.

## Description

Original task description moved to **Doc** folder
