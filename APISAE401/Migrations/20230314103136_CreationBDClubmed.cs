using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APISAE401.Migrations
{
    public partial class CreationBDClubmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_e_calendrier_cal",
                columns: table => new
                {
                    cld_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_calendrier", x => x.cld_date);
                });

            migrationBuilder.CreateTable(
                name: "t_e_cartebancaire_cc",
                columns: table => new
                {
                    cc_idcartebancaire = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cc_numerocb = table.Column<string>(type: "char(16)", maxLength: 16, nullable: true),
                    cc_dateexpirationcb = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cartebancaire", x => x.cc_idcartebancaire);
                });

            migrationBuilder.CreateTable(
                name: "t_e_club_clb",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    clb_latitude = table.Column<double>(type: "double precision", maxLength: 10, nullable: false),
                    clb_longitude = table.Column<double>(type: "double precision", maxLength: 10, nullable: false),
                    clb_description = table.Column<string>(type: "text", nullable: false),
                    clb_adresse = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    clb_tel = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    clb_mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_club", x => x.clb_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_commodite_cmd",
                columns: table => new
                {
                    cmd_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_type = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commodite", x => x.cmd_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_domaineskiable_skb",
                columns: table => new
                {
                    skb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    skb_titre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    skb_nom = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    skb_altitude = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    skb_longueurpiste = table.Column<double>(type: "double precision", maxLength: 50, nullable: false),
                    skb_nbpistes = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    skb_descritpion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_domaineskiable", x => x.skb_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_localisation_loc",
                columns: table => new
                {
                    loc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    loc_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localisation", x => x.loc_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_participant_pta",
                columns: table => new
                {
                    pta_idparticipant = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pta_genre = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    pta_nom = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    pta_prenom = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    pta_datenaissance = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participant", x => x.pta_idparticipant);
                });

            migrationBuilder.CreateTable(
                name: "t_e_pointfort_ptf",
                columns: table => new
                {
                    ptf_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ptf_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pointfort", x => x.ptf_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_regroupement_rgt",
                columns: table => new
                {
                    rgt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rgt_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regroupement", x => x.rgt_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_trancheage_tra",
                columns: table => new
                {
                    tra_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tra_detail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trancheage", x => x.tra_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_transport_tsp",
                columns: table => new
                {
                    tsp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tsp_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transport", x => x.tsp_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typeactivite_tat",
                columns: table => new
                {
                    tat_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tat_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tat_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeactivite", x => x.tat_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typechambre_tpc",
                columns: table => new
                {
                    tpc_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tpc_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tpc_dimension = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    tpc_capacite = table.Column<int>(type: "integer", nullable: false),
                    tpc_description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typechambre", x => x.tpc_id);
                    table.CheckConstraint("ck_tpc_capacite", "tpc_capacite > 0");
                });

            migrationBuilder.CreateTable(
                name: "t_e_typeclient_tpc",
                columns: table => new
                {
                    tpc_idtypeclient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tpc_intituletypeclient = table.Column<string>(type: "varchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeclient", x => x.tpc_idtypeclient);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typeclub_tcb",
                columns: table => new
                {
                    tcb_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tcb_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeclub", x => x.tcb_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_typesignalement_tsi",
                columns: table => new
                {
                    tsi_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tsi_titretype = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typesignalement", x => x.tsi_id);
                });

            migrationBuilder.CreateTable(
                name: "t_e_bar_bar",
                columns: table => new
                {
                    bar_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    bar_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    bar_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bar", x => x.bar_id);
                    table.ForeignKey(
                        name: "fk_bar_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_restaurant_rsn",
                columns: table => new
                {
                    rsn_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    rsn_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    rsn_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_restaurant", x => x.rsn_id);
                    table.ForeignKey(
                        name: "fk_restaurant_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_servicecommodite_sct",
                columns: table => new
                {
                    sct_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cmd_id = table.Column<int>(type: "integer", nullable: false),
                    sct_nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicecommodite", x => x.sct_id);
                    table.ForeignKey(
                        name: "fk_servicecommodites_commodite",
                        column: x => x.cmd_id,
                        principalTable: "t_e_commodite_cmd",
                        principalColumn: "cmd_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_appartient_ape",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    skb_id = table.Column<int>(type: "integer", nullable: false),
                    ape_altitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appartient", x => new { x.clb_id, x.skb_id });
                    table.ForeignKey(
                        name: "fk_appartient_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_appartient_domaineskiable",
                        column: x => x.skb_id,
                        principalTable: "t_e_domaineskiable_skb",
                        principalColumn: "skb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_souslocalisation_slo",
                columns: table => new
                {
                    slo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    loc_id = table.Column<int>(type: "integer", nullable: false),
                    slo_nom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_souslocalisation", x => x.slo_id);
                    table.ForeignKey(
                        name: "fk_souslocalisation_localisation",
                        column: x => x.loc_id,
                        principalTable: "t_e_localisation_loc",
                        principalColumn: "loc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_regrouper_rgr",
                columns: table => new
                {
                    rgt_id = table.Column<int>(type: "integer", nullable: false),
                    clb_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regrouper", x => new { x.clb_id, x.rgt_id });
                    table.ForeignKey(
                        name: "fk_regrouper_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_regrouper_regroupement",
                        column: x => x.rgt_id,
                        principalTable: "t_e_regroupement_rgt",
                        principalColumn: "rgt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_activite_act",
                columns: table => new
                {
                    act_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tra_id = table.Column<int>(type: "integer", nullable: false),
                    tat_id = table.Column<int>(type: "integer", nullable: false),
                    act_titre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    act_duree = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    act_description = table.Column<string>(type: "text", nullable: false),
                    act_agemin = table.Column<int>(type: "integer", nullable: false),
                    act_frequence = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activite", x => x.act_id);
                    table.ForeignKey(
                        name: "fk_activite_trancheage",
                        column: x => x.tra_id,
                        principalTable: "t_e_trancheage_tra",
                        principalColumn: "tra_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_activite_typeactivite",
                        column: x => x.tat_id,
                        principalTable: "t_e_typeactivite_tat",
                        principalColumn: "tat_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_apourpf_apf",
                columns: table => new
                {
                    tpc_id = table.Column<int>(type: "integer", nullable: false),
                    ptf_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_APourpf", x => new { x.ptf_id, x.tpc_id });
                    table.ForeignKey(
                        name: "fk_apourpf_pointfort",
                        column: x => x.ptf_id,
                        principalTable: "t_e_pointfort_ptf",
                        principalColumn: "ptf_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_apourpf_typechambre",
                        column: x => x.tpc_id,
                        principalTable: "t_e_typechambre_tpc",
                        principalColumn: "tpc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_comptabiliser_cpt",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    tpc_id = table.Column<int>(type: "integer", nullable: false),
                    cpt_nbchambre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comptabiliser", x => new { x.clb_id, x.tpc_id });
                    table.ForeignKey(
                        name: "fk_comptabiliser_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_comptabiliser_typechambre",
                        column: x => x.tpc_id,
                        principalTable: "t_e_typechambre_tpc",
                        principalColumn: "tpc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_tarif_trf",
                columns: table => new
                {
                    tpc_id = table.Column<int>(type: "integer", nullable: false),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    cld_date = table.Column<DateTime>(type: "date", nullable: false),
                    trf_prix = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tarif", x => new { x.tpc_id, x.clb_id, x.cld_date });
                    table.ForeignKey(
                        name: "fk_tarif_calendrier",
                        column: x => x.cld_date,
                        principalTable: "t_e_calendrier_cal",
                        principalColumn: "cld_date",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tarif_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tarif_typechambre",
                        column: x => x.tpc_id,
                        principalTable: "t_e_typechambre_tpc",
                        principalColumn: "tpc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_client_clt",
                columns: table => new
                {
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_tpc_idtypeclient = table.Column<int>(type: "integer", nullable: false),
                    clt_genre = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    clt_nom = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    clt_prenom = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    clt_datenaissance = table.Column<DateTime>(type: "date", nullable: false),
                    clt_mail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    clt_tel = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    clt_numeroadresse = table.Column<int>(type: "integer", nullable: true),
                    clt_adresse = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    clt_cp = table.Column<string>(type: "text", nullable: true),
                    clt_ville = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    clt_pays = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    clt_login = table.Column<string>(type: "varchar", maxLength: 255, nullable: true),
                    clt_pwd = table.Column<string>(type: "varchar", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => x.clt_id);
                    table.ForeignKey(
                        name: "fk_client_typeclient",
                        column: x => x.fk_tpc_idtypeclient,
                        principalTable: "t_e_typeclient_tpc",
                        principalColumn: "tpc_idtypeclient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_disposer_dps",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    tcp_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disposer", x => new { x.clb_id, x.tcp_id });
                    table.ForeignKey(
                        name: "fk_disposer_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_disposer_typeclub",
                        column: x => x.tcp_id,
                        principalTable: "t_e_typeclub_tcb",
                        principalColumn: "tcb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_photo_pht",
                columns: table => new
                {
                    pht_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bar_id = table.Column<int>(type: "integer", nullable: false),
                    tat_id = table.Column<int>(type: "integer", nullable: false),
                    rsn_id = table.Column<int>(type: "integer", nullable: false),
                    skb_id = table.Column<int>(type: "integer", nullable: false),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    tpc_id = table.Column<int>(type: "integer", nullable: false),
                    pht_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_photo", x => x.pht_id);
                    table.ForeignKey(
                        name: "fk_photo_bar",
                        column: x => x.bar_id,
                        principalTable: "t_e_bar_bar",
                        principalColumn: "bar_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_photo_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_photo_navigation",
                        column: x => x.skb_id,
                        principalTable: "t_e_domaineskiable_skb",
                        principalColumn: "skb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_photo_restaurant",
                        column: x => x.rsn_id,
                        principalTable: "t_e_restaurant_rsn",
                        principalColumn: "rsn_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_photo_typeactivite",
                        column: x => x.tat_id,
                        principalTable: "t_e_typeactivite_tat",
                        principalColumn: "tat_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_photo_typechambre",
                        column: x => x.tpc_id,
                        principalTable: "t_e_typechambre_tpc",
                        principalColumn: "tpc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_avoircomme_ace",
                columns: table => new
                {
                    sct_id = table.Column<int>(type: "integer", nullable: false),
                    tpc_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avoircomme", x => new { x.sct_id, x.tpc_id });
                    table.ForeignKey(
                        name: "fk_avoircomme_servicecommodite",
                        column: x => x.sct_id,
                        principalTable: "t_e_servicecommodite_sct",
                        principalColumn: "sct_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_avoircomme_typechambre",
                        column: x => x.tpc_id,
                        principalTable: "t_e_typechambre_tpc",
                        principalColumn: "tpc_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_apourloc_alc",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    slo_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_APourSousLoc", x => new { x.clb_id, x.slo_id });
                    table.ForeignKey(
                        name: "fk_apoursousloc_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_apoursousloc_souslocalisation",
                        column: x => x.slo_id,
                        principalTable: "t_e_souslocalisation_slo",
                        principalColumn: "slo_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_proposer_pro",
                columns: table => new
                {
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    act_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proposer", x => new { x.clb_id, x.act_id });
                    table.ForeignKey(
                        name: "fk_proposer_activite",
                        column: x => x.act_id,
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_proposer_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_avi_avi",
                columns: table => new
                {
                    avi_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    clu_id = table.Column<int>(type: "integer", nullable: false),
                    avi_titre = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    avi_note = table.Column<int>(type: "integer", nullable: false),
                    avi_commentaire = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avi", x => x.avi_id);
                    table.ForeignKey(
                        name: "fk_avi_client",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_avi_club",
                        column: x => x.clu_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_reservation_rsv",
                columns: table => new
                {
                    rsv_idreservation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    cld_datedebut = table.Column<DateTime>(type: "date", nullable: false),
                    cld_datefin = table.Column<DateTime>(type: "date", nullable: false),
                    rsv_datereservation = table.Column<DateTime>(type: "date", nullable: false),
                    rsv_montant = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservation", x => x.rsv_idreservation);
                    table.ForeignKey(
                        name: "fk_reservation_calendrierdebut",
                        column: x => x.cld_datedebut,
                        principalTable: "t_e_calendrier_cal",
                        principalColumn: "cld_date",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reservation_calendrierfin",
                        column: x => x.cld_datefin,
                        principalTable: "t_e_calendrier_cal",
                        principalColumn: "cld_date",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reservation_client",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reservation_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_detient_dtn",
                columns: table => new
                {
                    cc_id = table.Column<int>(type: "integer", nullable: false),
                    clt_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_detient", x => new { x.cc_id, x.clt_id });
                    table.ForeignKey(
                        name: "fk_detient_cartebancaire",
                        column: x => x.cc_id,
                        principalTable: "t_e_cartebancaire_cc",
                        principalColumn: "cc_idcartebancaire",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_detient_client",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_reponse_rps",
                columns: table => new
                {
                    rps_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clt_id = table.Column<int>(type: "integer", nullable: false),
                    clb_id = table.Column<int>(type: "integer", nullable: false),
                    avi_id = table.Column<int>(type: "integer", nullable: false),
                    rps_titre = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    rps_commentaire = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reponse", x => x.rps_id);
                    table.ForeignKey(
                        name: "fk_reponse_avis",
                        column: x => x.avi_id,
                        principalTable: "t_e_avi_avi",
                        principalColumn: "avi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reponse_client",
                        column: x => x.clt_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reponse_club",
                        column: x => x.clb_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_e_signalement_sig",
                columns: table => new
                {
                    sig_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cli_id = table.Column<int>(type: "integer", nullable: false),
                    clu_id = table.Column<int>(type: "integer", nullable: false),
                    avi_id = table.Column<int>(type: "integer", nullable: false),
                    tsi_id = table.Column<int>(type: "integer", nullable: false),
                    sig_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_signalement", x => x.sig_id);
                    table.ForeignKey(
                        name: "fk_signalement_avi",
                        column: x => x.avi_id,
                        principalTable: "t_e_avi_avi",
                        principalColumn: "avi_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_signalement_client",
                        column: x => x.cli_id,
                        principalTable: "t_e_client_clt",
                        principalColumn: "clt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_signalement_club",
                        column: x => x.clu_id,
                        principalTable: "t_e_club_clb",
                        principalColumn: "clb_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_signalement_typesignalement",
                        column: x => x.tsi_id,
                        principalTable: "t_e_typesignalement_tsi",
                        principalColumn: "tsi_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_deplacer_dpc",
                columns: table => new
                {
                    tsp_id = table.Column<int>(type: "integer", nullable: false),
                    rsv_idreservation = table.Column<int>(type: "integer", nullable: false),
                    dcp_lieu = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    dcp_montant = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deplacer", x => new { x.tsp_id, x.rsv_idreservation });
                    table.ForeignKey(
                        name: "fk_deplacer_reservation",
                        column: x => x.rsv_idreservation,
                        principalTable: "t_e_reservation_rsv",
                        principalColumn: "rsv_idreservation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_deplacer_transport",
                        column: x => x.tsp_id,
                        principalTable: "t_e_transport_tsp",
                        principalColumn: "tsp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_desirreserver_drv",
                columns: table => new
                {
                    rsv_idreservation = table.Column<int>(type: "integer", nullable: false),
                    tpc_id = table.Column<int>(type: "integer", nullable: false),
                    drv_nbparticipants = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_desirereserver", x => new { x.rsv_idreservation, x.tpc_id });
                    table.ForeignKey(
                        name: "fk_desirereserve_typechambre",
                        column: x => x.tpc_id,
                        principalTable: "t_e_typechambre_tpc",
                        principalColumn: "tpc_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_desirereserver_reservation",
                        column: x => x.rsv_idreservation,
                        principalTable: "t_e_reservation_rsv",
                        principalColumn: "rsv_idreservation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_participer_pte",
                columns: table => new
                {
                    pte_idparticipant = table.Column<int>(type: "integer", nullable: false),
                    rsv_idreservation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_participer", x => new { x.pte_idparticipant, x.rsv_idreservation });
                    table.ForeignKey(
                        name: "fk_participer_participant",
                        column: x => x.pte_idparticipant,
                        principalTable: "t_e_participant_pta",
                        principalColumn: "pta_idparticipant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_participer_reservation",
                        column: x => x.rsv_idreservation,
                        principalTable: "t_e_reservation_rsv",
                        principalColumn: "rsv_idreservation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_j_pouvoir_pou",
                columns: table => new
                {
                    rsv_idreservation = table.Column<int>(type: "integer", nullable: false),
                    act_id = table.Column<int>(type: "integer", nullable: false),
                    pou_prixmin = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pouvoir", x => new { x.rsv_idreservation, x.act_id });
                    table.ForeignKey(
                        name: "fk_pouvoir_activite",
                        column: x => x.act_id,
                        principalTable: "t_e_activite_act",
                        principalColumn: "act_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pouvoir_reservation",
                        column: x => x.rsv_idreservation,
                        principalTable: "t_e_reservation_rsv",
                        principalColumn: "rsv_idreservation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_tat_id",
                table: "t_e_activite_act",
                column: "tat_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_activite_act_tra_id",
                table: "t_e_activite_act",
                column: "tra_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avi_avi_clt_id",
                table: "t_e_avi_avi",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_avi_avi_clu_id",
                table: "t_e_avi_avi",
                column: "clu_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_bar_bar_bar_id",
                table: "t_e_bar_bar",
                column: "bar_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_bar_bar_clb_id",
                table: "t_e_bar_bar",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_clt_login",
                table: "t_e_client_clt",
                column: "clt_login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_clt_mail",
                table: "t_e_client_clt",
                column: "clt_mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_client_clt_fk_tpc_idtypeclient",
                table: "t_e_client_clt",
                column: "fk_tpc_idtypeclient");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_club_clb_clb_id",
                table: "t_e_club_clb",
                column: "clb_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_commodite_cmd_cmd_id",
                table: "t_e_commodite_cmd",
                column: "cmd_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_domaineskiable_skb_skb_id",
                table: "t_e_domaineskiable_skb",
                column: "skb_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_bar_id",
                table: "t_e_photo_pht",
                column: "bar_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_clb_id",
                table: "t_e_photo_pht",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_pht_id",
                table: "t_e_photo_pht",
                column: "pht_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_rsn_id",
                table: "t_e_photo_pht",
                column: "rsn_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_skb_id",
                table: "t_e_photo_pht",
                column: "skb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_tat_id",
                table: "t_e_photo_pht",
                column: "tat_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_photo_pht_tpc_id",
                table: "t_e_photo_pht",
                column: "tpc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_pointfort_ptf_ptf_id",
                table: "t_e_pointfort_ptf",
                column: "ptf_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reponse_rps_avi_id",
                table: "t_e_reponse_rps",
                column: "avi_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reponse_rps_clb_id",
                table: "t_e_reponse_rps",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reponse_rps_clt_id",
                table: "t_e_reponse_rps",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reponse_rps_rps_id",
                table: "t_e_reponse_rps",
                column: "rps_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rsv_clb_id",
                table: "t_e_reservation_rsv",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rsv_cld_datedebut",
                table: "t_e_reservation_rsv",
                column: "cld_datedebut");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rsv_cld_datefin",
                table: "t_e_reservation_rsv",
                column: "cld_datefin");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_reservation_rsv_clt_id",
                table: "t_e_reservation_rsv",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_restaurant_rsn_clb_id",
                table: "t_e_restaurant_rsn",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_restaurant_rsn_rsn_id",
                table: "t_e_restaurant_rsn",
                column: "rsn_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_servicecommodite_sct_cmd_id",
                table: "t_e_servicecommodite_sct",
                column: "cmd_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_servicecommodite_sct_sct_id",
                table: "t_e_servicecommodite_sct",
                column: "sct_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_signalement_sig_avi_id",
                table: "t_e_signalement_sig",
                column: "avi_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_signalement_sig_cli_id",
                table: "t_e_signalement_sig",
                column: "cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_signalement_sig_clu_id",
                table: "t_e_signalement_sig",
                column: "clu_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_signalement_sig_tsi_id",
                table: "t_e_signalement_sig",
                column: "tsi_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_souslocalisation_slo_loc_id",
                table: "t_e_souslocalisation_slo",
                column: "loc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_e_typeactivite_tat_tat_id",
                table: "t_e_typeactivite_tat",
                column: "tat_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_typeclient_tpc_tpc_intituletypeclient",
                table: "t_e_typeclient_tpc",
                column: "tpc_intituletypeclient",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_e_typeclub_tcb_tcb_id",
                table: "t_e_typeclub_tcb",
                column: "tcb_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_apourloc_alc_slo_id",
                table: "t_j_apourloc_alc",
                column: "slo_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_apourpf_apf_tpc_id",
                table: "t_j_apourpf_apf",
                column: "tpc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_appartient_ape_skb_id",
                table: "t_j_appartient_ape",
                column: "skb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_avoircomme_ace_tpc_id",
                table: "t_j_avoircomme_ace",
                column: "tpc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_comptabiliser_cpt_tpc_id",
                table: "t_j_comptabiliser_cpt",
                column: "tpc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_deplacer_dpc_rsv_idreservation",
                table: "t_j_deplacer_dpc",
                column: "rsv_idreservation");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_desirreserver_drv_tpc_id",
                table: "t_j_desirreserver_drv",
                column: "tpc_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_detient_dtn_clt_id",
                table: "t_j_detient_dtn",
                column: "clt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_disposer_dps_clb_id",
                table: "t_j_disposer_dps",
                column: "clb_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_disposer_dps_tcp_id",
                table: "t_j_disposer_dps",
                column: "tcp_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_j_participer_pte_rsv_idreservation",
                table: "t_j_participer_pte",
                column: "rsv_idreservation");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_pouvoir_pou_act_id",
                table: "t_j_pouvoir_pou",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_proposer_pro_act_id",
                table: "t_j_proposer_pro",
                column: "act_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_regrouper_rgr_rgt_id",
                table: "t_j_regrouper_rgr",
                column: "rgt_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_tarif_trf_clb_id",
                table: "t_j_tarif_trf",
                column: "clb_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_j_tarif_trf_cld_date",
                table: "t_j_tarif_trf",
                column: "cld_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_e_photo_pht");

            migrationBuilder.DropTable(
                name: "t_e_reponse_rps");

            migrationBuilder.DropTable(
                name: "t_e_signalement_sig");

            migrationBuilder.DropTable(
                name: "t_j_apourloc_alc");

            migrationBuilder.DropTable(
                name: "t_j_apourpf_apf");

            migrationBuilder.DropTable(
                name: "t_j_appartient_ape");

            migrationBuilder.DropTable(
                name: "t_j_avoircomme_ace");

            migrationBuilder.DropTable(
                name: "t_j_comptabiliser_cpt");

            migrationBuilder.DropTable(
                name: "t_j_deplacer_dpc");

            migrationBuilder.DropTable(
                name: "t_j_desirreserver_drv");

            migrationBuilder.DropTable(
                name: "t_j_detient_dtn");

            migrationBuilder.DropTable(
                name: "t_j_disposer_dps");

            migrationBuilder.DropTable(
                name: "t_j_participer_pte");

            migrationBuilder.DropTable(
                name: "t_j_pouvoir_pou");

            migrationBuilder.DropTable(
                name: "t_j_proposer_pro");

            migrationBuilder.DropTable(
                name: "t_j_regrouper_rgr");

            migrationBuilder.DropTable(
                name: "t_j_tarif_trf");

            migrationBuilder.DropTable(
                name: "t_e_bar_bar");

            migrationBuilder.DropTable(
                name: "t_e_restaurant_rsn");

            migrationBuilder.DropTable(
                name: "t_e_avi_avi");

            migrationBuilder.DropTable(
                name: "t_e_typesignalement_tsi");

            migrationBuilder.DropTable(
                name: "t_e_souslocalisation_slo");

            migrationBuilder.DropTable(
                name: "t_e_pointfort_ptf");

            migrationBuilder.DropTable(
                name: "t_e_domaineskiable_skb");

            migrationBuilder.DropTable(
                name: "t_e_servicecommodite_sct");

            migrationBuilder.DropTable(
                name: "t_e_transport_tsp");

            migrationBuilder.DropTable(
                name: "t_e_cartebancaire_cc");

            migrationBuilder.DropTable(
                name: "t_e_typeclub_tcb");

            migrationBuilder.DropTable(
                name: "t_e_participant_pta");

            migrationBuilder.DropTable(
                name: "t_e_reservation_rsv");

            migrationBuilder.DropTable(
                name: "t_e_activite_act");

            migrationBuilder.DropTable(
                name: "t_e_regroupement_rgt");

            migrationBuilder.DropTable(
                name: "t_e_typechambre_tpc");

            migrationBuilder.DropTable(
                name: "t_e_localisation_loc");

            migrationBuilder.DropTable(
                name: "t_e_commodite_cmd");

            migrationBuilder.DropTable(
                name: "t_e_calendrier_cal");

            migrationBuilder.DropTable(
                name: "t_e_client_clt");

            migrationBuilder.DropTable(
                name: "t_e_club_clb");

            migrationBuilder.DropTable(
                name: "t_e_trancheage_tra");

            migrationBuilder.DropTable(
                name: "t_e_typeactivite_tat");

            migrationBuilder.DropTable(
                name: "t_e_typeclient_tpc");
        }
    }
}
