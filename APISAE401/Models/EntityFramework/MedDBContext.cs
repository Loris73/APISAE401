using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APISAE401.Models.EntityFramework
{
    public partial class MedDBContext : DbContext
    {
        public MedDBContext()
        {
        }

        public MedDBContext(DbContextOptions<MedDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activite> Activites { get; set; } = null!;
        public virtual DbSet<ActiviteALaCarte> ActivitesALaCarte { get; set; } = null!;
        public virtual DbSet<ActiviteIncluse> ActivitesIncluses { get; set; } = null!;
        public virtual DbSet<APourSousLoc> APourLocs { get; set; } = null!;
        public virtual DbSet<APourPf> APourPfs { get; set; } = null!;
        public virtual DbSet<Avi> Avis { get; set; } = null!;
        public virtual DbSet<AvoirComme> AvoirCommes { get; set; } = null!;
        public virtual DbSet<Bar> Bars { get; set; } = null!;
        public virtual DbSet<Calendrier> Calendriers { get; set; } = null!;
        public virtual DbSet<CarteBancaire> CarteBancaires { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Club> Club { get; set; } = null!;
        public virtual DbSet<Commodite> Commodites { get; set; } = null!;
        public virtual DbSet<Comptabiliser> Comptabilisers { get; set; } = null!;
        public virtual DbSet<Deplacer> Deplacers { get; set; } = null!;
        public virtual DbSet<DesirReserve> DesirReserves { get; set; } = null!;
        public virtual DbSet<Detient> Detients { get; set; } = null!;
        public virtual DbSet<Disposer> Disposers { get; set; } = null!;
        public virtual DbSet<DomaineSkiable> DomaineSkiables { get; set; } = null!;
        public virtual DbSet<Localisation> Localisations { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Participer> Participers { get; set; } = null!;
        public virtual DbSet<Photo> Photos {get; set;} = null!;
        public virtual DbSet<PointFort> PointForts { get; set; } = null!;
        public virtual DbSet<Pouvoir> Pouvoirs { get; set; } = null!;
        public virtual DbSet<Proposer> Proposers { get; set; } = null!;
        public virtual DbSet<Regroupement> Regroupements { get; set; } = null!;
        public virtual DbSet<Regrouper> Regroupers { get; set; } = null!;
        public virtual DbSet<Reponse> Reponses { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<ServiceCommodite> ServiceCommodites { get; set; } = null!;
        public virtual DbSet<Signalement> Signalements { get; set; } = null!;
        public virtual DbSet<SousLocalisation> SousLocalisations { get; set; } = null!;
        public virtual DbSet<Tarif> Tarifs { get; set; } = null!;
        public virtual DbSet<TrancheAge> TrancheAges { get; set; } = null!;
        public virtual DbSet<Transport> Transports { get; set; } = null!;
        public virtual DbSet<TypeActivite> TypeActivites { get; set; } = null!;
        public virtual DbSet<TypeChambre> TypeChambres { get; set; } = null!;
        public virtual DbSet<TypeClient> TypeClients { get; set; } = null!;
        public virtual DbSet<TypeClub> TypeClubs { get; set; } = null!;
        public virtual DbSet<TypeSignalement> TypeSignalements { get; set; } = null!;
        
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=SAEMed; uid=postgres; password=postgres;");
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // ========= Activite ===============
             modelBuilder.Entity<Activite>(entity =>
            {
                entity.HasKey(e => e.IdActivite).HasName("pk_activite");
                entity.HasOne(d => d.TrancheageNavigation).WithMany(p => p.ActiviteNavigation)
                    .HasConstraintName("fk_activite_trancheage");

                entity.HasOne(d => d.TypeactiviteNavigation).WithMany(p => p.ActiviteNavigation)
                    .HasConstraintName("fk_activite_typeactivite");
            });

            // ========= Activite A La Carte ===============
             modelBuilder.Entity<ActiviteALaCarte>(entity =>
            {
                 entity.HasKey(e => new {e.IdActiviteALaCarte, e.IdActivite}).HasName("pk_activitealacarte");

                entity.HasOne(d => d.ActiviteNavigation).WithMany(p => p.ActivitealacarteNavigation)
                    .HasConstraintName("fk_activitealacarte_activite");
            });
                

            // ========= Activite Incluse ===============
                modelBuilder.Entity<ActiviteIncluse>(entity =>
            {
                 entity.HasKey(e => new { e.IdActiviteIncluse, e.IdActivite }).HasName("pk_activiteincluse");


                entity.HasOne(d => d.ActiviteNavigation).WithMany(p => p.ActiviteincluseNavigation)
                    .HasConstraintName("fk_activiteincluse_activite");
            });

            // ========= A Pour Point Fort ===============
                 modelBuilder.Entity<APourPf>(entity =>
                {
                    entity.HasKey(e => new {e.IdPointFort, e.IdTypeChambre}).HasName("pk_APourpf");// pas sure
    
                    entity.HasOne(d => d.PointfortNaviguation).WithMany(p => p.ApourpfNavigation)
                        .HasConstraintName("fk_apourpf_pointfort");
    
    
                    entity.HasOne(d => d.TypechambreNavigation).WithMany(p => p.ApourpfNavigation)
                        .HasConstraintName("fk_apourpf_typechambre");
                });


            // ========= Appartient ===============
                modelBuilder.Entity<Appartient>(entity =>
            {
                entity.HasKey(e => new {e.IdClub, e.IdDommaineSkiable}).HasName("pk_appartient");

                entity.HasOne(d => d.ClubNaviguation).WithMany(p => p.AppartientNavigation)
                    .HasConstraintName("fk_appartient_club");

                entity.HasOne(d => d.DomaineskiableNavigation).WithMany(p => p.AppartientNavigation)
                    .HasConstraintName("fk_appartient_domaineskiable");
            });



            // ========= A Pour Localisation ===============
             modelBuilder.Entity<APourSousLoc>(entity =>
            {
                entity.HasKey(e => new {e.IdClub, e.IdLocalisation}).HasName("pk_APourPF");// pas sure

                entity.HasOne(d => d.LocalisationNavigation).WithMany(p => p.ApourlocNavigation)
                    .HasConstraintName("fk_apourloc_localisation");


                entity.HasOne(d => d.ClubNavigation).WithMany(p => p.ApourlocNavigation)
                    .HasConstraintName("fk_apourloc_club");
            });

           

            //=================Avis==================
            modelBuilder.Entity<Avi>(entity =>
            {
                entity.HasKey(e => e.IdAvi).HasName("pk_avi");
            });

            // ============ Bar ===============
             modelBuilder.Entity<Bar>(entity =>
            {
            entity.HasKey(e => e.IdBar).HasName("pk_bar");
            });

            // ========= Client ===============
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient).HasName("pk_client");
                entity.HasOne(e => e.TypeclientNavigation).WithMany(t => t.ClientNavigation)
                .HasConstraintName("fk_client_typeclient");
            });


            // ========= Calendrier ===============
            modelBuilder.Entity<Calendrier>(entity =>
            {
                entity.HasKey(e => e.DateCal).HasName("pk_calendrier");
            });

            // ========= CarteBancaire ===============
            modelBuilder.Entity<CarteBancaire>(entity =>
            {
                entity.HasKey(e => e.IdCarteBancaire).HasName("pk_cartebancaire");
            });

            // ========= Club ===============
             modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(e => e.IdClub).HasName("pk_club");
            });


            //=============Commodite===================
            modelBuilder.Entity<Commodite>(entity =>
            {
                entity.HasKey(e => e.IdCommodite).HasName("pk_commodite");
            });
            

            // ========= Deplacer ===============
            modelBuilder.Entity<Deplacer>(entity =>
            {
                entity.HasKey(e => new {e.IdTransport, e.IdReservation}).HasName("pk_deplacer");// pas sure

                entity.HasOne(e => e.TransportNavigation).WithMany(p => p.DeplacerNavigation)
                    .HasConstraintName("fk_deplacer_transport");

                entity.HasOne(e => e.ReservationNavigation).WithMany(p => p.DeplacerNavigation)
                    .HasConstraintName("fk_deplacer_reservation");
            });

            // ========= Detient ===============
            modelBuilder.Entity<Detient>(entity =>
            {
                entity.HasKey(e => new {e.IdCarteBancaire, e.IdClient}).HasName("pk_detient");

                entity.HasOne(e => e.CartebancaireNavigation).WithMany(p => p.DetientNavigation)
                    .HasConstraintName("fk_detient_cartebancaire");

                entity.HasOne(e => e.ClientNavigation).WithMany(p => p.DetientNavigation)
                    .HasConstraintName("fk_detient_client");
            });

            // ========= Disposer ===============
            modelBuilder.Entity<Disposer>(entity =>
            {
                entity.HasKey(e => new {e.IdClub, e.IdTypeClub}).HasName("pk_disposer");

                entity.HasOne(e => e.ClubNavigation).WithMany(p => p.DisposerNavigation)
                    .HasConstraintName("fk_disposer_club");

                entity.HasOne(e => e.TypeclubNavigation).WithMany(p => p.DisposerNavigation)
                    .HasConstraintName("fk_disposer_typeclub");
            });

            // ========== Domaine Skiable 
                modelBuilder.Entity<DomaineSkiable>(entity =>
                {
                entity.HasKey(e => e.IdDomaineSkiable).HasName("pk_domaineskiable");
                });

            // ========= Localisation ===============
             modelBuilder.Entity<Localisation>(entity =>
            {
                entity.HasKey(e => e.IdLocalisation).HasName("pk_localisation");
            });

            // ========= Participant ===============
            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => e.IdParticipant).HasName("pk_participant");
            });

            // ========= Point Fort ===============
             modelBuilder.Entity<PointFort>(entity =>
            {
                entity.HasKey(e => e.IdPointFort).HasName("pk_pointfort");

            });

            //============= Proposer ============
            modelBuilder.Entity<Proposer>(entity =>
            {
                entity.HasKey( e => new {e.IdClub, e.IdActivite}).HasName("pk_proposer"); // pas sure

                entity.HasOne(e => e.ClubNavigation).WithMany(p => p.ProposerNavigation)
                    .HasConstraintName("fk_proposer_club");
                    
            });

            //================Regroupements===================
            modelBuilder.Entity<Regroupement>(entity =>
            {
                entity.HasKey(e => e.RegroupementId).HasName("pk_regroupement");
            });

            // ========= Regrouper ===============
             modelBuilder.Entity<Regrouper>(entity =>
            {
                entity.HasKey(e => new {e.IdClub, e.RegroupementId}).HasName("pk_regrouper");// pas sure

                entity.HasOne(d => d.RegroupementNavigation).WithMany(p => p.RegrouperNavigation)
                    .HasConstraintName("fk_regrouper_regroupement");

                entity.HasOne(d => d.ClubNavigation).WithMany(p => p.RegrouperNavigation)
                    .HasConstraintName("fk_regrouper_club");
            });

            //============Reponse===================
            modelBuilder.Entity<Reponse>(entity =>
            {
                entity.HasKey(e => e.IdReponse).HasName("pk_reponse");
            });
            
            // ========= Reservation ===============
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation).HasName("pk_reservation");

                entity.HasOne(e => e.CalendrierNavigation).WithMany(p => p.ReservationNavigation)
                    .HasConstraintName("fk_reservation_calendrier");

                entity.HasOne(e => e.ClientNavigation).WithMany(p => p.ReservationNavigation)
                    .HasConstraintName("fk_reservation_client");

                entity.HasOne(e => e.ClubNavigation).WithMany(p => p.ReservationNavigation)
                    .HasConstraintName("fk_reservation_club");
            });
            
            // ============ Restaurant ===============
             modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant).HasName("pk_restaurant");
            });
            
            //================== Service Commodites ===================
            modelBuilder.Entity<ServiceCommodite>(entity =>
            {
                entity.HasKey(e => e.IdServiceCommodite).HasName("pk_servicecommodite");
            });

            // ========= Signalement ===================
             modelBuilder.Entity<Signalement>(entity =>
             {
                 entity.HasKey(e => e.IdSignalement).HasName("pk_signalement");
             });
            
            // ========= Sous localisation ===============    Quelqu'un pour faire cette merde ?
             modelBuilder.Entity<SousLocalisation>(entity =>
            {
                entity.HasKey(e => new {e.IdLocalisation, e.IdSousLocalisation}).HasName("pk_souslocalisation");// pas sure

                entity.HasOne(d => d.PointfortNaviguation).WithMany(p => p.SousLocalisationNavigation)
                    .HasConstraintName("PointFortId");


                entity.HasOne(d => d.TypeChambreNavigation).WithMany(p => p.SousLocalisationNavigation)
                    .HasConstraintName("TypeChambreId");
            });


            // ========= Tarif ===============
             modelBuilder.Entity<Tarif>(entity =>
            {
                entity.HasOne(d => d.TypechambreNavigation).WithMany(p => p.TarifNavigation)
                    .HasConstraintName("fk_tarif_typechambre");

                entity.HasOne(d => d.ClubNavigation).WithMany(p => p.TarifNavigation)
                    .HasConstraintName("fk_tarif_club");

                entity.HasOne(d => d.CalendrierNavigation).WithMany(p => p.TarifNavigation)
                    .HasConstraintName("fk_tarif_calendrier");
            });


            //===============Tranche Age ===================
            modelBuilder.Entity<TrancheAge>(entity =>
            {
                entity.HasKey(e => e.IdTrancheAge).HasName("pk_trancheage");
            });

            //=========== Transport =================
            modelBuilder.Entity<Transport>(entity =>
            {
                entity.HasKey(e => e.IdTransport).HasName("pk_transport");
            });

            // ========= Type Activite ===============
             modelBuilder.Entity<TypeActivite>(entity =>
            {
                entity.HasKey(e => e.IdTypeActivite).HasName("pk_typeactivite");
                entity.HasCheckConstraint("ck_tat_capacite", "tat_capacite min 0");
            });


            // ========= Type Chambre ===============
             modelBuilder.Entity<TypeChambre>(entity =>
            {
                entity.HasKey(e => e.TypeChambreId).HasName("pk_typechambre");
                entity.HasCheckConstraint("ck_tpc_capacite", "tpc_capacite > 0");
            });

            // ========= TypeClient ===============
            modelBuilder.Entity<TypeClient>(entity =>
            {
                entity.HasKey(e => e.IdTypeClient).HasName("pk_typeclient");
            });

            // ========= Type Club ===============
            modelBuilder.Entity<TypeClub>(entity =>
            {
                entity.HasKey(e => e.IdTypeClub).HasName("pk_typeclub");
                
            });
            
            // ========= Type Signalement ===============
            modelBuilder.Entity<TypeSignalement>(entity =>
            {
                entity.HasKey(e => e.IdTypeSignalement).HasName("pk_typesignalement");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}