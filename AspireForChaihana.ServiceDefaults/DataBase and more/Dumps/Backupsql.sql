CREATE TABLE IF NOT EXISTS "Categories" (
    "CategoryId" uuid PRIMARY KEY,
    "Name" text NOT NULL
);

CREATE TABLE IF NOT EXISTS "Products" (
    "ProductId" uuid PRIMARY KEY,
    "Name" text NOT NULL,
    "Description" text,
    "Price" numeric NOT NULL,
    "Weight" double precision NOT NULL,
    "ImageUrl" text NOT NULL,
    "CategoryId" uuid NOT NULL,
    FOREIGN KEY ("CategoryId") REFERENCES "Categories" ("CategoryId")
);

INSERT INTO "Categories" ("CategoryId", "Name")
VALUES 
    ('11111111-1111-1111-1111-111111111111', 'Напитки'),
    ('22222222-2222-2222-2222-222222222222', 'Десерты')
ON CONFLICT DO NOTHING;

INSERT INTO "Products" ("ProductId", "Name", "Description", "Price", "Weight", "ImageUrl", "CategoryId")
VALUES 
    ('33333333-3333-3333-3333-333333333333', 'Чай', 'Ароматный чай', 100.00, 0.2, 'tea.jpg', '11111111-1111-1111-1111-111111111111'),
    ('44444444-4444-4444-4444-444444444444', 'Пирожное', 'Вкусное пирожное', 150.00, 0.15, 'cake.jpg', '22222222-2222-2222-2222-222222222222')
ON CONFLICT DO NOTHING;