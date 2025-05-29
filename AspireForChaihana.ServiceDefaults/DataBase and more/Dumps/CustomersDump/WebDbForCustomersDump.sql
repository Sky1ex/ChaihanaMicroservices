--CREATE DATABASE "WebDbForCustomers";

BEGIN;

CREATE TABLE IF NOT EXISTS public."AddressElements"
(
    "AddressElementId" uuid NOT NULL,
    "City" text COLLATE pg_catalog."default" NOT NULL,
    "Street" text COLLATE pg_catalog."default" NOT NULL,
    "House" text COLLATE pg_catalog."default" NOT NULL,
    "Apartment" integer NOT NULL,
    CONSTRAINT "PK_AddressElements" PRIMARY KEY ("AddressElementId")
);

CREATE TABLE IF NOT EXISTS public."Orders"
(
    "OrderId" uuid NOT NULL,
    "dateTime" timestamp with time zone NOT NULL,
    "AdressAddressElementId" uuid NOT NULL,
    "Sum" integer NOT NULL,
    "UserId" uuid,
    CONSTRAINT "PK_Orders" PRIMARY KEY ("OrderId")
);

CREATE TABLE IF NOT EXISTS public."Users"
(
    "UserId" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default",
    "Phone" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_Users" PRIMARY KEY ("UserId")
);

CREATE TABLE IF NOT EXISTS public."Adresses"
(
    "AdressId" uuid NOT NULL,
    "City" text COLLATE pg_catalog."default" NOT NULL,
    "Street" text COLLATE pg_catalog."default" NOT NULL,
    "House" text COLLATE pg_catalog."default" NOT NULL,
    "Apartment" integer NOT NULL,
    "UserId" uuid,
    CONSTRAINT "PK_Adresses" PRIMARY KEY ("AdressId")
);

CREATE TABLE IF NOT EXISTS public."Bookings"
(
    "BookingId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Table" integer NOT NULL,
    "Time" timestamp with time zone NOT NULL,
    "Interval" integer NOT NULL,
    CONSTRAINT "PK_Bookings" PRIMARY KEY ("BookingId")
);

CREATE TABLE IF NOT EXISTS public."Carts"
(
    "CartId" uuid NOT NULL,
    CONSTRAINT "PK_Carts" PRIMARY KEY ("CartId")
);

CREATE TABLE IF NOT EXISTS public."CartElements"
(
    "CartElementId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Count" integer NOT NULL,
    "CartId" uuid,
    CONSTRAINT "PK_CartElements" PRIMARY KEY ("CartElementId")
);

CREATE TABLE IF NOT EXISTS public."OrderElements"
(
    "OrderElementId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Count" integer NOT NULL,
    "OrderId" uuid,
    CONSTRAINT "PK_OrderElements" PRIMARY KEY ("OrderElementId")
);

ALTER TABLE IF EXISTS public."Orders"
    ADD CONSTRAINT "FK_Orders_AddressElements_AdressAddressElementId" FOREIGN KEY ("AdressAddressElementId")
    REFERENCES public."AddressElements" ("AddressElementId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_Orders_AdressAddressElementId"
    ON public."Orders"("AdressAddressElementId");


ALTER TABLE IF EXISTS public."Orders"
    ADD CONSTRAINT "FK_Orders_Users_UserId" FOREIGN KEY ("UserId")
    REFERENCES public."Users" ("UserId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_Orders_UserId"
    ON public."Orders"("UserId");


ALTER TABLE IF EXISTS public."Adresses"
    ADD CONSTRAINT "FK_Adresses_Users_UserId" FOREIGN KEY ("UserId")
    REFERENCES public."Users" ("UserId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_Adresses_UserId"
    ON public."Adresses"("UserId");


ALTER TABLE IF EXISTS public."Bookings"
    ADD CONSTRAINT "FK_Bookings_Users_UserId" FOREIGN KEY ("UserId")
    REFERENCES public."Users" ("UserId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_Bookings_UserId"
    ON public."Bookings"("UserId");


ALTER TABLE IF EXISTS public."Carts"
    ADD CONSTRAINT "FK_Carts_Users_CartId" FOREIGN KEY ("CartId")
    REFERENCES public."Users" ("UserId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "PK_Carts"
    ON public."Carts"("CartId");


ALTER TABLE IF EXISTS public."CartElements"
    ADD CONSTRAINT "FK_CartElements_Carts_CartId" FOREIGN KEY ("CartId")
    REFERENCES public."Carts" ("CartId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_CartElements_CartId"
    ON public."CartElements"("CartId");


ALTER TABLE IF EXISTS public."OrderElements"
    ADD CONSTRAINT "FK_OrderElements_Orders_OrderId" FOREIGN KEY ("OrderId")
    REFERENCES public."Orders" ("OrderId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION;
CREATE INDEX IF NOT EXISTS "IX_OrderElements_OrderId"
    ON public."OrderElements"("OrderId");

INSERT INTO "Users" ("UserId", "Name", "Phone")
VALUES ('5d378c1c-e04c-4416-b13d-941fd9a8fdd5', NULL, NULL),
    ('c528fe2d-bf43-4549-988c-52e28043c85d', 'Владислав', '79127363081'),
    ('f12eae1b-3aa1-4ca9-9807-390558f40a74', NULL, NULL)
On CONFLICT DO NOTHING;

INSERT INTO "Carts" ("CartId")
VALUES ('5d378c1c-e04c-4416-b13d-941fd9a8fdd5'),
    ('c528fe2d-bf43-4549-988c-52e28043c85d'),
    ('f12eae1b-3aa1-4ca9-9807-390558f40a74')
On CONFLICT DO NOTHING;

INSERT INTO "Adresses" ("AdressId", "City", "Street", "House", "Apartment", "UserId")
VALUES ('0474c449-efa5-4488-88e6-64a506b1f13b',	'Киров', 'улица Ленина', '196', 43, NULL),
    ('16ee107b-96eb-41fd-ac2f-7e47b109dc06', 'Киров', 'Милицейская улица', '33', 41, 'c528fe2d-bf43-4549-988c-52e28043c85d'),
    ('4568f93d-57fd-4ad9-a373-0f18ede97dc4', 'Киров', 'улица Дерендяева', '104', 53, NULL),
    ('5d7d7af7-ba40-4b4a-aca0-c14c68ca2bbe', 'Киров', 'улица Ивана Попова', '62', 64, NULL),
    ('6c328c29-2390-4de8-966f-e3789b37f5f1','Киров', 'улица Калинина', '2', 4, NULL),
    ('7e348024-7050-482a-9075-e6525db87982','Киров','Пролетарская улица','46',64,'c528fe2d-bf43-4549-988c-52e28043c85d'),
    ('848166ee-8097-4391-b04c-7849190c36bc','Киров','улица Ленина','102В', 41, NULL),
    ('cfdbb253-742c-43b7-96ed-ccccfdf3638f','Киров','Мостовицкая улица','5',21, NULL),
    ('8d8f1486-bd6e-4eeb-bdea-baa32c45cb83','Киров','улица Воровского','21', 54, NULL)
On CONFLICT DO NOTHING;

INSERT INTO "AddressElements" ("AddressElementId", "City", "Street", "House", "Apartment")
VALUES ('4568f93d-57fd-4ad9-a373-0f18ede97dc4', 'Киров', 'улица Дерендяева', '104', 53),
    ('4f9fe57e-d7e4-42b7-9ad2-547274a43587', 'Киров', 'улица Калинина', '2', 4),
    ('7702b68f-e0fc-47be-a4eb-8f5bab07381c', 'Киров', 'улица Карла Либкнехта', '146', 12)
On CONFLICT DO NOTHING;

INSERT INTO "Orders" ("OrderId", "dateTime", "AdressAddressElementId", "Sum", "UserId")
VALUES ('5e1f2076-3d98-4d94-99d2-3b1616e7b287', '2025-05-06 17:08:20.101675+03', '4f9fe57e-d7e4-42b7-9ad2-547274a43587', 139, 'c528fe2d-bf43-4549-988c-52e28043c85d'),
    ('73ee8a42-feb0-481b-957d-10fa7b8fa168', '2025-03-18 20:30:36.582292+03', '7702b68f-e0fc-47be-a4eb-8f5bab07381c', 798, 'c528fe2d-bf43-4549-988c-52e28043c85d'),
    ('dac2431d-971b-4ca6-b54a-bc00eb7f9666', '2025-03-19 00:13:43.690027+03', '4568f93d-57fd-4ad9-a373-0f18ede97dc4', 399, 'c528fe2d-bf43-4549-988c-52e28043c85d')
On CONFLICT DO NOTHING;

INSERT INTO "CartElements" ("CartElementId", "ProductId", "Count", "CartId")
VALUES  ('4c4fd076-a2b2-4756-bfdf-87d2c77c4195', 'e6956753-25ce-4370-9084-e21ec279edbb', 1, 'c528fe2d-bf43-4549-988c-52e28043c85d')
On CONFLICT DO NOTHING;

INSERT INTO "OrderElements" ("OrderElementId", "ProductId", "Count", "OrderId")
VALUES ('25cbc6b2-b81c-4a47-b99b-d3b16d12a9f6', 'ebca3033-dd4a-4f09-b786-55cdcd7c46fe', 2, 'dac2431d-971b-4ca6-b54a-bc00eb7f9666'),
    ('6829f700-5c85-4a99-ab7c-5b777e1de0fb', '3a3994d1-86d5-47e2-86e3-488a0e8b48fc', 2, '73ee8a42-feb0-481b-957d-10fa7b8fa168'),
    ('7923a96a-c804-41cb-8e73-e48c6b7220ea', '8c8491f9-b615-49e3-b181-7a7fa0d9fd1f', 1, '5e1f2076-3d98-4d94-99d2-3b1616e7b287'),
    ('81cdd2fc-67f8-44a7-9acc-35c0403b6532', 'ebca3033-dd4a-4f09-b786-55cdcd7c46fe', 4, '73ee8a42-feb0-481b-957d-10fa7b8fa168'),
    ('be3d5164-c329-47a4-92f6-2e3b27b17aff', '3a3994d1-86d5-47e2-86e3-488a0e8b48fc', 1, 'dac2431d-971b-4ca6-b54a-bc00eb7f9666')
On CONFLICT DO NOTHING;


END;