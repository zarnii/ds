-- Table: public.Permission

-- DROP TABLE IF EXISTS public."Permission";

CREATE TABLE IF NOT EXISTS public."Permission"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Permission_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Permission"
    OWNER to postgres;