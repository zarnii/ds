-- Table: public.RoleTextchannelMap

-- DROP TABLE IF EXISTS public."RoleTextchannelMap";

CREATE TABLE IF NOT EXISTS public."RoleTextchannelMap"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "RoleId" uuid NOT NULL,
    "TextChannelId" uuid NOT NULL,
    CONSTRAINT "RoleTextchannelMap_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "RoleTextchannelMap_RoleId_fkey" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "RoleTextchannelMap_TextChannelId_fkey" FOREIGN KEY ("TextChannelId")
        REFERENCES public."TextChannel" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."RoleTextchannelMap"
    OWNER to postgres;