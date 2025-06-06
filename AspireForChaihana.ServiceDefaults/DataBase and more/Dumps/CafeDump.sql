PGDMP      2        
        }            WebDbForCafe    17.2    17.2     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    41412    WebDbForCafe    DATABASE     �   CREATE DATABASE "WebDbForCafe" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "WebDbForCafe";
                     postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false            �           0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4            �            1259    41542 
   Categories    TABLE     _   CREATE TABLE public."Categories" (
    "CategoryId" uuid NOT NULL,
    "Name" text NOT NULL
);
     DROP TABLE public."Categories";
       public         heap r       postgres    false    4            �            1259    41549    Products    TABLE     �   CREATE TABLE public."Products" (
    "ProductId" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text,
    "Price" numeric NOT NULL,
    "Weight" double precision NOT NULL,
    "ImageUrl" text NOT NULL,
    "CategoryId" uuid NOT NULL
);
    DROP TABLE public."Products";
       public         heap r       postgres    false    4            �            1259    41537    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap r       postgres    false    4            �          0    41542 
   Categories 
   TABLE DATA           <   COPY public."Categories" ("CategoryId", "Name") FROM stdin;
    public               postgres    false    218   �       �          0    41549    Products 
   TABLE DATA           u   COPY public."Products" ("ProductId", "Name", "Description", "Price", "Weight", "ImageUrl", "CategoryId") FROM stdin;
    public               postgres    false    219   �       �          0    41537    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public               postgres    false    217   �       +           2606    41548    Categories PK_Categories 
   CONSTRAINT     d   ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "PK_Categories" PRIMARY KEY ("CategoryId");
 F   ALTER TABLE ONLY public."Categories" DROP CONSTRAINT "PK_Categories";
       public                 postgres    false    218            .           2606    41555    Products PK_Products 
   CONSTRAINT     _   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "PK_Products" PRIMARY KEY ("ProductId");
 B   ALTER TABLE ONLY public."Products" DROP CONSTRAINT "PK_Products";
       public                 postgres    false    219            )           2606    41541 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public                 postgres    false    217            ,           1259    41561    IX_Products_CategoryId    INDEX     W   CREATE INDEX "IX_Products_CategoryId" ON public."Products" USING btree ("CategoryId");
 ,   DROP INDEX public."IX_Products_CategoryId";
       public                 postgres    false    219            /           2606    41556 *   Products FK_Products_Categories_CategoryId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "FK_Products_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."Categories"("CategoryId") ON DELETE CASCADE;
 X   ALTER TABLE ONLY public."Products" DROP CONSTRAINT "FK_Products_Categories_CategoryId";
       public               postgres    false    4651    218    219            �   �   x��;JEA��3{�$��${���=�� ����)��M���`!_��]H-�Ur�:��c�"v&��������Q��������/	�2�As����k����M��z+p،]��	��NB�M����v������̅�T�
F��	�>���3n������	mاX8����{5-%s$��z>G�kX�ߥ�� �6V      �   �  x��W�n\�\7��?p�>�M$Km�i
�# e/��%8v ��b'� 
1",�����Q�/���*3��p�է�:�lJ���22	?rS��4��v���۱O���b�	e��Q(-�Oo���ɍ�H�ҽ�ί�/���9�H.d�G¿id���/xq�)�j]'�M"�B�T|�n9vY�)Չ���,��{�N�	�?B���(�e��|���q��Qd��]Zo�פNE�II���܃&#}�=&����x>^��K�	�{�U�Q9�-�5eY#E�R�2K����,����r\��6B���5���q�{'���{�-ɜ@nf��9�K�s`eKJGT�B��xJ�j�I�=��(�7�j>[�W8����S�>�= T�9xw��I�)�e�q��)k�C�����e�b�m5��V������G����v|o��cR�³�K�$9J�;S;���;i���$�;�
Պ*��"���l��N�_���	d}��vr������-��.��`:�;j5�VB��'1�,�O��kѽ0'}]���ч[��eљ����b��멻�sd����2��,��F�����]`���J:��P̔|����*F��7��*_.��ˣqv�r��ˣ����c4�m���צco�������dЏ�k����(�u�L�Z+����͔�^��w��en�%h� _��=����^#����/>5#+c�[��4�M�=8�c�<<O�A��t�oiq�N�n�ܢ�t�1�W1�)�j���l!��Q��\2��E|�k��;���#.�!�xSJ�&�܍aL4��D�.�g�I�؋ܝa�bq�,��8�Tl�W�&Ɨ�ȗߎ� C������<�XG^�i=�R��Q��8[���������~7KU�����k���Z����tQ��ժF�{M-W�a��		C���:h�m����**��>J��C�0S�!��]QBn��W�䬦�_�+��9���kP`���{Uu.a�-���K%�t�M�DJ���H�W�3�����>+���4�3WK/:p�5t�Zc�����ڛ�h{�!���V�R��<��)�2D�Nw��i�����|�I�f]^�J0�;Ju�'#�#�]�'ߑb�����K4UX��9ޡ�}���e��+f:ٜq2o
��R5b�U^^u9�	���� S��j���DQᡮK����A�_�m�<<�{y��CS2�����<���4���P�_��\D��0�~8�����]�dl�%� Bk��S�bZp����[qyx����d�¸vf9��T�R���pY�׵6-9]�1l����i�n���J�޽u�N�����oì5��Õu�����wU�o�0c�an��{�O,��|�X��cr�.j�&���*�P��ؤ�[���s9��f����or2�
�b�؆P�C`���u�ZU�����r���e�R�%v-�0=�SU��8��NԾZ>Ǵ1��OĀ��9�r���k���}���Tg;nW�f	Ulv���Pņ.*)#�m}��<�)�[^�<ֻT�k�$�M�`xH���fji�=��7���L�5*���������A�F�-ӵfKKd˦��`����:M���2�5�����n��K�Rk�u���[Z[[j�������ԥPk+�ܱ�Z�vƽ<�w�)�(ԊgY�2���\|Xz�eM�5�]w�m%���6����B�)ch�L�+�2��s60���A����-�g�ν�[�ҍw�De�$      �   0   x�3202505�026450����,�L�q.JM,I��3�3����� �Y	�     