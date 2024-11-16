-- Table: public.TextChannel

-- DROP TABLE IF EXISTS public."TextChannel";

CREATE TABLE IF NOT EXISTS public."TextChannel"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "SlowModeTimeout" integer,
    CONSTRAINT "TextChannel_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TextChannel"
    OWNER to postgres;