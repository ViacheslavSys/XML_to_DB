using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XML_to_DB;

public partial class BdForShopContext : DbContext
{
    public BdForShopContext()
    {
    }

    public BdForShopContext(DbContextOptions<BdForShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<КатегорииТоваров> КатегорииТоваровs { get; set; }

    public virtual DbSet<КорзинаПользователя> КорзинаПользователяs { get; set; }

    public virtual DbSet<ПокупкиТоваровПользователями> ПокупкиТоваровПользователямиs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<ПоставщикиТоваров> ПоставщикиТоваровs { get; set; }

    public virtual DbSet<Товары> Товарыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9A8P37P\\MSSQLSERVER02;Database=bd_for_shop;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<КатегорииТоваров>(entity =>
        {
            entity.HasKey(e => e.IdКатегорииТовара);

            entity.ToTable("Категории_товаров");

            entity.Property(e => e.IdКатегорииТовара).HasColumnName("id_категории_товара");
            entity.Property(e => e.НазваниеКатегорииТовара)
                .HasMaxLength(50)
                .HasColumnName("Название_категории_товара");
            entity.Property(e => e.ОписаниеКатегорииТовара).HasColumnName("Описание_категории_товара");
        });

        modelBuilder.Entity<КорзинаПользователя>(entity =>
        {
            entity.HasKey(e => e.IdЗаказа);

            entity.ToTable("Корзина_пользователя");

            entity.Property(e => e.IdЗаказа).HasColumnName("id_заказа");
            entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");
            entity.Property(e => e.АдресДоставки)
                .HasMaxLength(50)
                .HasColumnName("Адрес_доставки");
            entity.Property(e => e.ВремяЗаказа).HasColumnName("Время_заказа");
            entity.Property(e => e.ДатаЗаказа).HasColumnName("Дата_заказа");
            entity.Property(e => e.СпособПолучения)
                .HasMaxLength(50)
                .HasColumnName("Способ_получения");
            entity.Property(e => e.СтатусЗаказа)
                .HasMaxLength(15)
                .HasColumnName("Статус_заказа");
            entity.Property(e => e.СтоимостьЗаказа)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Стоимость_заказа");

            entity.HasOne(d => d.IdПользователяNavigation).WithMany(p => p.КорзинаПользователяs)
                .HasForeignKey(d => d.IdПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Корзина_пользователя_Пользователи");
        });

        modelBuilder.Entity<ПокупкиТоваровПользователями>(entity =>
        {
            entity
                //.HasNoKey()
                .ToTable("Покупки_товаров_пользователями");

            entity.Property(e => e.IdЗаказа).HasColumnName("Id_заказа");
            entity.Property(e => e.IdТовара).HasColumnName("Id_товара");
            entity.Property(e => e.КоличествоТовара).HasColumnName("Количество_товара");

            entity.HasOne(d => d.IdЗаказаNavigation).WithMany()
                .HasForeignKey(d => d.IdЗаказа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Покупки_товаров_пользователями_Корзина_пользователя");

            entity.HasOne(d => d.IdТовараNavigation).WithMany()
                .HasForeignKey(d => d.IdТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Покупки_товаров_пользователями_Товары");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.IdПользователя);

            entity.ToTable("Пользователи");

            entity.Property(e => e.IdПользователя).HasColumnName("id_пользователя");
            entity.Property(e => e.EmailПользователя)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email_пользователя");
            entity.Property(e => e.ДатаРегистрации).HasColumnName("Дата_регистрации");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата_рождения");
            entity.Property(e => e.ИмяПользователя)
                .HasMaxLength(50)
                .HasColumnName("Имя_пользователя");
            entity.Property(e => e.Логин)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Пароль)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Пол).HasMaxLength(8);
            entity.Property(e => e.ТелефонПользователя)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Телефон_пользователя");
        });

        modelBuilder.Entity<ПоставщикиТоваров>(entity =>
        {
            entity.HasKey(e => e.IdПоставщика);

            entity.ToTable("Поставщики_товаров");

            entity.Property(e => e.IdПоставщика).HasColumnName("id_поставщика");
            entity.Property(e => e.EmailПоставщика)
                .HasMaxLength(50)
                .HasColumnName("Email_поставщика");
            entity.Property(e => e.АдресПоставщика)
                .HasMaxLength(50)
                .HasColumnName("Адрес_поставщика");
            entity.Property(e => e.НаименованиеПоставщика)
                .HasMaxLength(50)
                .HasColumnName("Наименование_поставщика");
            entity.Property(e => e.ТелефонПоставщика)
                .HasMaxLength(50)
                .HasColumnName("Телефон_поставщика");
        });

        modelBuilder.Entity<Товары>(entity =>
        {
            entity.HasKey(e => e.IdТовара);

            entity.ToTable("Товары");

            entity.Property(e => e.IdТовара).HasColumnName("id_товара");
            entity.Property(e => e.IdКатегорииТовара).HasColumnName("id_категории_товара");
            entity.Property(e => e.IdПоставщика).HasColumnName("id_поставщика");
            entity.Property(e => e.АртикулТовара)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("Артикул_товара");
            entity.Property(e => e.ВесТовара)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("Вес_товара");
            entity.Property(e => e.НазваниеТовара)
                .HasMaxLength(50)
                .HasColumnName("Название_товара");
            entity.Property(e => e.ОписаниеТовара).HasColumnName("Описание_товара");
            entity.Property(e => e.РазмерыТовара)
                .HasMaxLength(50)
                .HasColumnName("Размеры_товара");
            entity.Property(e => e.ЦенаТовара)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Цена_товара");

            entity.HasOne(d => d.IdКатегорииТовараNavigation).WithMany(p => p.Товарыs)
                .HasForeignKey(d => d.IdКатегорииТовара)
                .HasConstraintName("FK_Товары_Категории_товаров1");

            entity.HasOne(d => d.IdПоставщикаNavigation).WithMany(p => p.Товарыs)
                .HasForeignKey(d => d.IdПоставщика)
                .HasConstraintName("FK_Товары_Поставщики_товаров");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
