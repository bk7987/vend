CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "Reviews" (
    "Id" text NOT NULL,
    "Rating" integer NOT NULL,
    "Upvotes" integer NOT NULL,
    "ReviewText" text NULL,
    CONSTRAINT "PK_Reviews" PRIMARY KEY ("Id")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200814163329_InitialMigration', '3.1.7');