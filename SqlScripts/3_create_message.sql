-- Table: public.Message

-- DROP TABLE IF EXISTS public."Message";

CREATE TABLE IF NOT EXISTS public."Message"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Text" text COLLATE pg_catalog."default" NOT NULL,
    "AuthorId" uuid NOT NULL,
    "ReplyToId" uuid,
    "SendTime" timestamp without time zone NOT NULL,
    "IsChanged" boolean NOT NULL DEFAULT false,
    CONSTRAINT "Message_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "Message_AuthorId_fkey" FOREIGN KEY ("AuthorId")
        REFERENCES public."User" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Message_ReplyToId_fkey" FOREIGN KEY ("ReplyToId")
        REFERENCES public."Message" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Message"
    OWNER to postgres;