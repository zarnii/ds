-- Table: public.User

-- DROP TABLE IF EXISTS public."User";

CREATE TABLE IF NOT EXISTS public."User"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Username" text COLLATE pg_catalog."default" NOT NULL,
    "Login" text COLLATE pg_catalog."default" NOT NULL,
    "Password" text COLLATE pg_catalog."default" NOT NULL,
    "Identity" bigint NOT NULL DEFAULT nextval('"User_Identity_seq"'::regclass),
    CONSTRAINT "User_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "User_Identity_key" UNIQUE ("Identity"),
    CONSTRAINT "User_Login_key" UNIQUE ("Login")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."User"
    OWNER to postgres;