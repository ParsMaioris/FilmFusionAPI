# FilmFusion API

## Overview

FilmFusion API is a .NET 7 web API project, designed to interface with the MovieDB external API. This project aims to provide practical scenarios for creating and working with C# APIs, focusing on movie-related data.

## Features

- **Controllers**: Includes various controllers such as MoviesController, CreatorsController, and GenresController, catering to different aspects of movie data.
- **External API Integration**: Utilizes the MovieDB API for fetching movie-related data.
- **API Key Management**: Implements .NET Secrets for secure API key and access token management.

## Getting Started

### Prerequisites

- .NET 7 SDK
- MovieDB API key and access token

### Setting Up API Keys

1. Visit the MovieDB website and register for an API key and access token.
2. Use the following .NET CLI commands to securely store your API key and access token using .NET Secrets:
   ```
   dotnet user-secrets init
   dotnet user-secrets set "MovieDB:ApiKey" "<your-api-key>"
   dotnet user-secrets set "MovieDB:AccessToken" "<your-access-token>"
   ```

## Architecture

- **HTTP Client Wrapper**: Manages the communication with the MovieDB API.
- **Service Classes**: Process the data retrieved from MovieDB and perform operations using LINQ.
- **C# Constructs**: The project is a showcase for various C# features and practices.

## Contributing

Contributions are welcome. Please fork the repository and submit a pull request for review.

## License

[MIT License](LICENSE)

## Acknowledgments

- MovieDB for providing the API used in this project.
