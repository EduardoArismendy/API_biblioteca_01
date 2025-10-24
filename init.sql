-- ===========================================
-- 📚 BASE DE DATOS: Librería Digital
-- ===========================================
CREATE DATABASE API_Biblioteca_01_DB;
GO

USE API_Biblioteca_01_DB;
GO

-- ===========================================
-- 🧍 TABLA: Users
-- ===========================================
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);
GO

-- ===========================================
-- 📖 TABLA: Books
-- Cada usuario puede tener varios libros.
-- ===========================================
CREATE TABLE Books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Author NVARCHAR(150) NOT NULL,
    PublicationYear INT CHECK (PublicationYear >= 0),
    CoverImageUrl NVARCHAR(500) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,

    CONSTRAINT FK_Books_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE CASCADE
);
GO

-- ===========================================
-- 🌟 TABLA: Reviews
-- Un usuario puede dejar una reseña y calificación
-- por cada libro.
-- ===========================================
CREATE TABLE Reviews (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BookId INT NOT NULL,
    UserId INT NOT NULL,
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    Comment NVARCHAR(1000) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),

    CONSTRAINT FK_Reviews_Books FOREIGN KEY (BookId)
        REFERENCES Books(Id)
        ON DELETE CASCADE,

    CONSTRAINT FK_Reviews_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE NO ACTION
);
GO
