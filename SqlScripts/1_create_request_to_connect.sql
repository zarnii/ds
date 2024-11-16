-- Table: public.RequestToConnect

-- DROP TABLE IF EXISTS public."RequestToConnect";

CREATE TABLE IF NOT EXISTS public."RequestToConnect"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Username" text COLLATE pg_catalog."default" NOT NULL,
    "Login" text COLLATE pg_catalog."default" NOT NULL,
    "Password" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "RequestToConnect_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."RequestToConnect"
    OWNER to postgres;