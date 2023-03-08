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
        public virtual DbSet<APourLoc> APourLocs { get; set; } = null!;
        public virtual DbSet<APourPf> APourPfs { get; set; } = null!;
        public virtual DbSet<Avis> AvisSet { get; set; } = null!;
        public virtual DbSet<AvoirComme> AvoirCommes { get; set; } = null!;
        public virtual DbSet<Bar> Bars { get; set; } = null!;
        public virtual DbSet<Calendrier> Calendriers { get; set; } = null!;
        public virtual DbSet<CarteBancaire> CarteBancaires { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Club> Club { get; set; } = null!;
        public virtual DbSet<Commodites> CommoditesSet { get; set; } = null!;
        public virtual DbSet<Comptabiliser> Comptabilisers { get; set; } = null!;
        public virtual DbSet<Deplacer> Deplacers { get; set; } = null!;
        public virtual DbSet<DesirReserve> DesirReserves { get; set; } = null!;
        public virtual DbSet<Detient> Detients { get; set; } = null!;
        public virtual DbSet<Disposer> Disposers { get; set; } = null!;
        public virtual DbSet<DomaineSkiable> DomaineSkiables { get; set; } = null!;
        public virtual DbSet<Localisation> Localisations { get; set; } = null!;
        public virtual DbSet<Participant> Participants { get; set; } = null!;
        public virtual DbSet<Participer> Participers { get; set; } = null!;
        public virtual DbSet<PointFort> PointForts { get; set; } = null!;
        public virtual DbSet<Pouvoir> Pouvoirs { get; set; } = null!;
        public virtual DbSet<Proposer> Proposers { get; set; } = null!;
        public virtual DbSet<Regroupement> Regroupements { get; set; } = null!;
        public virtual DbSet<Regrouper> Regroupers { get; set; } = null!;
        public virtual DbSet<Reponse> Reponses { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;
        public virtual DbSet<ServiceCommodites> ServiceCommoditesSet { get; set; } = null!;
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
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}