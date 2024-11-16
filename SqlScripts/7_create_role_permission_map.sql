-- Table: public.RolePermissionMap

-- DROP TABLE IF EXISTS public."RolePermissionMap";

CREATE TABLE IF NOT EXISTS public."RolePermissionMap"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "RoleId" uuid NOT NULL,
    "PermissionId" uuid NOT NULL,
    CONSTRAINT "RolePermissionMap_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "RolePermissionMap_PermissionId_fkey" FOREIGN KEY ("PermissionId")
        REFERENCES public."Permission" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "RolePermissionMap_RoleId_fkey" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."RolePermissionMap"
    OWNER to postgres;