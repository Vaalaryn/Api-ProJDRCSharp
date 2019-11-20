/*==============================================================*/
/* Nom de SGBD :  MySQL 5.0                                     */
/* Date de création :  20/11/2019 13:18:22                      */
/*==============================================================*/


drop table if exists CLASSE;

drop table if exists IMAGE;

drop table if exists JOUEUR;

drop table if exists LOG;

drop table if exists OBJET;

drop table if exists PARTIE;

drop table if exists PERSONNAGE;

drop table if exists STOCK;

drop table if exists UTILISATEUR;

/*==============================================================*/
/* Table : CLASSE                                               */
/*==============================================================*/
create table CLASSE
(
   ID_CLASSE            int not null auto_increment,
   MAX_VIE              smallint not null,
   MAX_MANA             smallint not null,
   PUISSANCE                smallint not null,
   MAGIE                smallint not null,
   DEXTERITE            smallint not null,
   OBSERVATION          smallint not null,
   INTELLIGENCE         smallint not null,
   CHANCE               smallint not null,
   CHARISME             smallint not null,
   DESIGNATION          varchar(50) not null,
   DESCRIPTION          text,
   primary key (ID_CLASSE)
);

/*==============================================================*/
/* Table : IMAGE                                                */
/*==============================================================*/
create table IMAGE
(
   ID_IMAGE             int not null auto_increment,
   ID_PARTIE            varchar(16) not null,
   IMAGE                longblob not null,
   DATEAJOUT            datetime not null default NOW(),
   primary key (ID_IMAGE)
);

/*==============================================================*/
/* Table : JOUEUR                                               */
/*==============================================================*/
create table JOUEUR
(
   ID_JOUEUR            int not null auto_increment,
   ID_UTIL              int not null,
   ID_PARTIE            varchar(16) not null,
   IS_MJ                bool not null,
   primary key (ID_JOUEUR)
);

/*==============================================================*/
/* Table : LOG                                                  */
/*==============================================================*/
create table LOG
(
   ID_LOG               int not null auto_increment,
   ID_PARTIE            varchar(16) not null,
   TYPE                 smallint not null,
   MESSAGE              varchar(255) not null,
   DATE_ENVOI           datetime not null default NOW(),
   primary key (ID_LOG)
);

/*==============================================================*/
/* Table : OBJET                                                */
/*==============================================================*/
create table OBJET
(
   ID_OBJET             int not null auto_increment,
   NOM_OBJET            varchar(50),
   DESC_OBJET           text,
   ATTRIBUT             text,
   primary key (ID_OBJET)
);

/*==============================================================*/
/* Table : PARTIE                                               */
/*==============================================================*/
create table PARTIE
(
   ID_PARTIE            varchar(16) not null,
   TITRE                varchar(255) not null,
   DESCRIPTION_PARTIE   text,
   primary key (ID_PARTIE)
);

/*==============================================================*/
/* Table : PERSONNAGE                                           */
/*==============================================================*/
create table PERSONNAGE
(
   ID_PERSO             int not null auto_increment,
   ID_CLASSE            int not null,
   ID_JOUEUR            int not null,
   NOM                  varchar(50) not null,
   PRENOM               varchar(50) not null,
   VIVANT               bool not null,
   DESCRIPTION          text,
   BLOCNOTE             varchar(255),
   VIE                  smallint,
   MANA                 smallint default 0,
   EXPERIENCE           int default 0,
   NIVEAU               int default 1,
   primary key (ID_PERSO)
);

/*==============================================================*/
/* Table : STOCK                                                */
/*==============================================================*/
create table STOCK
(
   ID_INVENTAIRE        int not null auto_increment,
   ID_PERSO             int not null,
   ID_OBJET             int not null,
   QUANTITE             smallint not null,
   primary key (ID_INVENTAIRE)
);

/*==============================================================*/
/* Table : UTILISATEUR                                          */
/*==============================================================*/
create table UTILISATEUR
(
   ID_UTIL              int not null auto_increment,
   MAIL                 varchar(140) not null,
   PSEUDO               varchar(40) not null,
   MDP                  varchar(40) not null,
   AVATAR               longblob not null,
   primary key (ID_UTIL)
);

alter table IMAGE add constraint FK_ASSOCIATION_7 foreign key (ID_PARTIE)
      references PARTIE (ID_PARTIE) on delete restrict on update restrict;

alter table JOUEUR add constraint FK_ASSOCIATION_5 foreign key (ID_UTIL)
      references UTILISATEUR (ID_UTIL) on delete restrict on update restrict;

alter table JOUEUR add constraint FK_LIE foreign key (ID_PARTIE)
      references PARTIE (ID_PARTIE) on delete restrict on update restrict;

alter table LOG add constraint FK_ASSOCIATION_6 foreign key (ID_PARTIE)
      references PARTIE (ID_PARTIE) on delete restrict on update restrict;

alter table PERSONNAGE add constraint FK_APPARTIENT foreign key (ID_CLASSE)
      references CLASSE (ID_CLASSE) on delete restrict on update restrict;

alter table PERSONNAGE add constraint FK_POSSEDE foreign key (ID_JOUEUR)
      references JOUEUR (ID_JOUEUR) on delete restrict on update restrict;

alter table STOCK add constraint FK_ASSOCIATION_8 foreign key (ID_PERSO)
      references PERSONNAGE (ID_PERSO) on delete restrict on update restrict;

alter table STOCK add constraint FK_ASSOCIATION_9 foreign key (ID_OBJET)
      references OBJET (ID_OBJET) on delete restrict on update restrict;

