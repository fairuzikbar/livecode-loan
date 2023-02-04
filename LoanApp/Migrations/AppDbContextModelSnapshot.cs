﻿// <auto-generated />
using System;
using LoanApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoanApp.Entities.Loan.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("dob");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("phone");

                    b.Property<int?>("ProfilePictureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfilePictureId");

                    b.ToTable("m_customer");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.GuaranteePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("content_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("path");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.HasKey("Id");

                    b.ToTable("t_guarantee_picture");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.InstallmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InstalmentType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("m_installment_type");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.LoanDocuments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("content_type");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("customer_id");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("t_loan_documents");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.LoanTransaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("approvalStatus")
                        .HasColumnType("int");

                    b.Property<long>("approvedAt")
                        .HasColumnType("bigint")
                        .HasColumnName("approved_at");

                    b.Property<string>("approvedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("approved_by");

                    b.Property<long>("createdAt")
                        .HasColumnType("bigint")
                        .HasColumnName("created_at");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<int>("installmentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("loanTypeId")
                        .HasColumnType("int");

                    b.Property<double>("nominal")
                        .HasColumnType("float")
                        .HasColumnName("nominal");

                    b.Property<long>("updatedAt")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_at");

                    b.HasKey("id");

                    b.HasIndex("customerId");

                    b.HasIndex("installmentTypeId");

                    b.HasIndex("loanTypeId");

                    b.ToTable("t_loan_transaction");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.LoanType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("MaxLoan")
                        .HasColumnType("float")
                        .HasColumnName("max_loan");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("m_loan_type");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.ProfilePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("content_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("m_profile_picture");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.TransactionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("CreatedDate")
                        .HasColumnType("bigint")
                        .HasColumnName("created_date");

                    b.Property<int>("GuaranteePictureId")
                        .HasColumnType("int");

                    b.Property<int>("LoanStatus")
                        .HasColumnType("int");

                    b.Property<int>("LoanTransactionid")
                        .HasColumnType("int");

                    b.Property<double>("Nominal")
                        .HasColumnType("float")
                        .HasColumnName("nominal");

                    b.Property<long>("TransactionDate")
                        .HasColumnType("bigint")
                        .HasColumnName("transaction_date");

                    b.Property<long>("UpdatedDate")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_date");

                    b.HasKey("Id");

                    b.HasIndex("GuaranteePictureId");

                    b.HasIndex("LoanTransactionid");

                    b.ToTable("t_transaction_detail");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.Customer", b =>
                {
                    b.HasOne("LoanApp.Entities.Loan.ProfilePicture", "ProfilePicture")
                        .WithMany()
                        .HasForeignKey("ProfilePictureId");

                    b.Navigation("ProfilePicture");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.LoanDocuments", b =>
                {
                    b.HasOne("LoanApp.Entities.Loan.Customer", "Customer")
                        .WithMany("LoanDocuments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.LoanTransaction", b =>
                {
                    b.HasOne("LoanApp.Entities.Loan.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanApp.Entities.Loan.InstallmentType", "installmentType")
                        .WithMany()
                        .HasForeignKey("installmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanApp.Entities.Loan.LoanType", "loanType")
                        .WithMany()
                        .HasForeignKey("loanTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("installmentType");

                    b.Navigation("loanType");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.TransactionDetail", b =>
                {
                    b.HasOne("LoanApp.Entities.Loan.GuaranteePicture", "GuaranteePicture")
                        .WithMany()
                        .HasForeignKey("GuaranteePictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LoanApp.Entities.Loan.LoanTransaction", "LoanTransaction")
                        .WithMany("loanTransactionDetails")
                        .HasForeignKey("LoanTransactionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuaranteePicture");

                    b.Navigation("LoanTransaction");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.Customer", b =>
                {
                    b.Navigation("LoanDocuments");
                });

            modelBuilder.Entity("LoanApp.Entities.Loan.LoanTransaction", b =>
                {
                    b.Navigation("loanTransactionDetails");
                });
#pragma warning restore 612, 618
        }
    }
}