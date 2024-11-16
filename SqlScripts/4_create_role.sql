-- Table: public.Role

-- DROP TABLE IF EXISTS public."Role";

CREATE TABLE IF NOT EXISTS public."Role"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Role_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Role_Name_key" UNIQUE ("Name")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Role"
    OWNER to postgres;