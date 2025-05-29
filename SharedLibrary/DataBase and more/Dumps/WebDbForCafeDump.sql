CREATE DATABASE IF NOT EXISTS "WebDbForCafe";

BEGIN;

CREATE TABLE IF NOT EXISTS public."Categories"
(
    "CategoryId" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_Categories" PRIMARY KEY ("CategoryId")
);

CREATE TABLE IF NOT EXISTS public."Products"
(
    "ProductId" uuid NOT NULL,
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    "Price" numeric NOT NULL,
    "Weight" double precision NOT NULL,
    "ImageUrl" text COLLATE pg_catalog."default" NOT NULL,
    "CategoryId" uuid NOT NULL,
    CONSTRAINT "PK_Products" PRIMARY KEY ("ProductId")
);

CREATE TABLE IF NOT EXISTS public."__EFMigrationsHistory"
(
    "MigrationId" character varying(150) COLLATE pg_catalog."default" NOT NULL,
    "ProductVersion" character varying(32) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

ALTER TABLE IF EXISTS public."Products"
    ADD CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId")
    REFERENCES public."Categories" ("CategoryId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE CASCADE;
CREATE INDEX IF NOT EXISTS "IX_Products_CategoryId"
    ON public."Products"("CategoryId");

INSERT INTO public."Categories" ("CategoryId", "Name") VALUES
("7819a2c5-4822-4b5f-9cbf-0190076164df","Десерты"),
("81ca10e7-67f8-4b46-b942-4677f8f05742","Чаи"),
("890f7535-0bac-4b1e-af18-6a2718125c98","Блюда"),
("a2b26636-081c-4179-a1de-809581f7c809","Салаты"),
("a4210af3-ec8a-4689-9163-6f0e4a93326f","Закуски")
On Conflict Do Nothing;

INSERT INTO public."Products" ("ProductId", "Name", "CategoryId", "Price", "Weight", "ImageUrl", "Description") VALUES
('14ce5c6c-50a8-4aa8-be2c-5ce2a1df4a22', 'Табуле', 'a2b26636-081c-4179-a1de-809581f7c809', 24, 309, 'Images\\Salate.png', NULL),
('1a84d56f-634a-428e-ac7a-f519f0cc4cd6', 'Маття', '81ca10e7-67f8-4b46-b942-4677f8f05742', 16, 179, 'Images\\Tea.png', NULL),
('1da38663-8600-4f12-bf83-407b0f9a5866', 'Кимун', '81ca10e7-67f8-4b46-b942-4677f8f05742', 17, 139, 'Images\\Tea.png', NULL),
('1dd71926-19b5-43b3-b0d9-962af00b0235', 'Карбонара', '890f7535-0bac-4b1e-af18-6a2718125c98', 3, 329, 'Images\\Carbonara.png', NULL),
('23977829-d623-46c7-a0d8-e4e090fce519', 'Селдь под шубой', 'a2b26636-081c-4179-a1de-809581f7c809', 25, 299, 'Images\\Salate.png', NULL),
('24a66207-eb0b-4b8f-b308-e5358d8ab0cf', 'Наполеон', '7819a2c5-4822-4b5f-9cbf-0190076164df', 33, 179, 'Images\\Desert.png', NULL),
('24e1201f-3664-4e60-9b9f-7d10ec2cf5dc', 'Бешбармак', '890f7535-0bac-4b1e-af18-6a2718125c98', 6, 279, 'Images\\Beshbarmak.png', NULL),
('2f699e9f-84f4-48c5-9f79-ed83ec8f7f4a', 'Чучвара', '890f7535-0bac-4b1e-af18-6a2718125c98', 7, 409, 'Images\\Chuchvara.png', NULL),
('30c3b1d8-64a2-4263-af6b-84b7b47012bc', 'Поке', 'a2b26636-081c-4179-a1de-809581f7c809', 23, 339, 'Images\\Salate.png', NULL),
('3169f73d-39fc-419b-a789-3c0895214e02', 'Овощные роллы с хумусом', 'a4210af3-ec8a-4689-9163-6f0e4a93326f', 31, 299, 'Images\\Cheburek.png', NULL),
('35f4f831-bd32-4737-a06d-2511ec4c20ac', 'Шопский салат', 'a2b26636-081c-4179-a1de-809581f7c809', 26, 269, 'Images\\Salate.png', NULL),
('37ae40d1-19ec-4684-80bf-1f863b9b4a21', 'Шашлык', '890f7535-0bac-4b1e-af18-6a2718125c98', 9, 389, 'Images\\Shashlik.png', NULL),
('3a3994d1-86d5-47e2-86e3-488a0e8b48fc', 'Чебурек', 'a4210af3-ec8a-4689-9163-6f0e4a93326f', 1, 99, 'Images\\Cheburek.png', NULL),
('3b492276-069a-4109-9781-0da171f44133', 'Оливье', 'a2b26636-081c-4179-a1de-809581f7c809', 20, 245, 'Images\\Salate.png', NULL),
('5a9c6409-b106-4466-9338-29e7521d816e', 'Лунцзин', '81ca10e7-67f8-4b46-b942-4677f8f05742', 15, 149, 'Images\\Tea.png', NULL),
('619acc56-70b2-4b25-8358-cd1065c75dff', 'Капрезе', 'a2b26636-081c-4179-a1de-809581f7c809', 22, 239, 'Images\\Salate.png', NULL),
('6cedc37b-fc0b-4172-852e-13fdaebd7f25', 'Гречневые оладьи', 'a4210af3-ec8a-4689-9163-6f0e4a93326f', 29, 129, 'Images\\Cheburek.png', NULL),
('6eb88d60-6f76-43f2-ae5c-d9572a4bb233', 'Губадия', '7819a2c5-4822-4b5f-9cbf-0190076164df', 37, 309, 'Images\\Desert.png', NULL),
('72d3bc83-ec93-4439-acad-30d98abcf1a2', 'Каркаде', '81ca10e7-67f8-4b46-b942-4677f8f05742', 12, 169, 'Images\\Tea.png', NULL),
('7b22ae03-1ec4-4139-bd4f-8c381e9d8f1f', 'Кутабы', 'a4210af3-ec8a-4689-9163-6f0e4a93326f', 30, 159, 'Images\\Cheburek.png', NULL),
('85205fdd-9024-4aa7-be4c-bc9b5b563f17', 'Шакер-чурек', '7819a2c5-4822-4b5f-9cbf-0190076164df', 34, 279, 'Images\\Desert.png', NULL),
('8c8491f9-b615-49e3-b181-7a7fa0d9fd1f', 'Кукси', 'a4210af3-ec8a-4689-9163-6f0e4a93326f', 28, 139, 'Images\\Cheburek.png', NULL),
('8e37d5bd-5104-4d09-a5bb-0174c1cbead4', 'Эрл Грей', '81ca10e7-67f8-4b46-b942-4677f8f05742', 14, 159, 'Images\\Tea.png', NULL),
('95b50599-ad5e-43fa-9242-f3cc2301354f', 'Цезарь', 'a2b26636-081c-4179-a1de-809581f7c809', 19, 209, 'Images\\Salate.png', NULL),
('a382bef2-cb29-4955-8e7d-2088ce39b464', 'Рахат-лукум', '7819a2c5-4822-4b5f-9cbf-0190076164df', 35, 239, 'Images\\Desert.png', NULL),
('a4585cb8-59b4-4a7c-a5a9-c4e8641e52a4', 'Шоу мэй', '81ca10e7-67f8-4b46-b942-4677f8f05742', 18, 145, 'Images\\Tea.png', NULL),
('a7ea28fd-abd6-4822-b3de-6f334ea6496b', 'Болоньезе', '890f7535-0bac-4b1e-af18-6a2718125c98', 4, 379, 'Images\\Boloneize.png', NULL),
('b331eaf8-cffa-4b70-9830-6d58b7e0c11c', 'Винегрет', 'a2b26636-081c-4179-a1de-809581f7c809', 21, 225, 'Images\\Salate.png', NULL),
('b3544bf0-63c2-4463-aded-d8d9c614ae8f', 'Да хун пао', '81ca10e7-67f8-4b46-b942-4677f8f05742', 11, 179, 'Images\\Tea.png', NULL),
('ba4e4cad-b966-4e8f-a567-e13965d52dcb', 'Пуэр', '81ca10e7-67f8-4b46-b942-4677f8f05742', 13, 159, 'Images\\Tea.png', NULL),
('bcb880cb-1d86-4924-bad2-9e8f9226a3ad', 'Лепёшка «Оби-нон»', 'a4210af3-ec8a-4689-9163-6f0e4a93326f', 27, 145, 'Images\\Cheburek.png', NULL),
('d65f3b36-4e0c-45b6-8374-db25c2a2401f', 'Медовик', '7819a2c5-4822-4b5f-9cbf-0190076164df', 36, 269, 'Images\\Desert.png', NULL),
('d9006151-5ac4-411a-99bd-ee4dceeaa702', 'Самса', '890f7535-0bac-4b1e-af18-6a2718125c98', 10, 259, 'Images\\Samsa.png', NULL),
('e6956753-25ce-4370-9084-e21ec279edbb', 'Плов', '890f7535-0bac-4b1e-af18-6a2718125c98', 5, 239, 'Images\\Plov.png', NULL),
('ebca3033-dd4a-4f09-b786-55cdcd7c46fe', 'Улун', '81ca10e7-67f8-4b46-b942-4677f8f05742', 2, 150, 'Images\\Tea.png', NULL),
('ef8adf10-4af4-48e9-87a8-8dd942137ca4', 'Чак-чак', '7819a2c5-4822-4b5f-9cbf-0190076164df', 32, 149, 'Images\\Desert.png', NULL),
('f77962f9-510e-416e-9444-ab0ce6cb9fef', 'Манты', '890f7535-0bac-4b1e-af18-6a2718125c98', 8, 419, 'Images\\Mantie.png', NULL)
On CONFLICT DO NOTHING;

END;