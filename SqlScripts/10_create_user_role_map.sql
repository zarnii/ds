-- Table: public.UserRoleMap

-- DROP TABLE IF EXISTS public."UserRoleMap";

CREATE TABLE IF NOT EXISTS public."UserRoleMap"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL,
    CONSTRAINT "UserRoleMap_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "UserRoleMap_RoleId_fkey" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "UserRoleMap_UserId_fkey" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UserRoleMap"
    OWNER to postgres;