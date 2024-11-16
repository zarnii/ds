-- Table: public.MessageTextchannelMap

-- DROP TABLE IF EXISTS public."MessageTextchannelMap";

CREATE TABLE IF NOT EXISTS public."MessageTextchannelMap"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "MessageId" uuid NOT NULL,
    "TextChannelId" uuid NOT NULL,
    CONSTRAINT "MessageTextchannelMap_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "MessageTextchannelMap_MessageId_fkey" FOREIGN KEY ("MessageId")
        REFERENCES public."Message" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "MessageTextchannelMap_TextChannelId_fkey" FOREIGN KEY ("TextChannelId")
        REFERENCES public."TextChannel" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."MessageTextchannelMap"
    OWNER to postgres;