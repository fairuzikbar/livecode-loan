using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_installment_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstalmentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_installment_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_loan_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(50)", nullable: false),
                    maxloan = table.Column<double>(name: "max_loan", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_loan_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_profile_picture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    contenttype = table.Column<string>(name: "content_type", type: "varchar(50)", nullable: false),
                    url = table.Column<string>(type: "varchar(250)", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_profile_picture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_guarantee_picture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    contenttype = table.Column<string>(name: "content_type", type: "varchar(50)", nullable: false),
                    path = table.Column<string>(type: "varchar(250)", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_guarantee_picture", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(50)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(50)", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "varchar(14)", nullable: false),
                    ProfilePictureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_m_customer_m_profile_picture_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "m_profile_picture",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "t_loan_documents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<string>(name: "customer_id", type: "nvarchar(max)", nullable: false),
                    contenttype = table.Column<string>(name: "content_type", type: "varchar(50)", nullable: false),
                    url = table.Column<string>(type: "varchar(250)", nullable: false),
                    size = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_loan_documents", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_loan_documents_m_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "m_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_loan_transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loanTypeId = table.Column<int>(type: "int", nullable: false),
                    installmentTypeId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    nominal = table.Column<double>(type: "float", nullable: false),
                    approvedat = table.Column<long>(name: "approved_at", type: "bigint", nullable: false),
                    approvedby = table.Column<string>(name: "approved_by", type: "nvarchar(max)", nullable: false),
                    approvalStatus = table.Column<int>(type: "int", nullable: false),
                    createdat = table.Column<long>(name: "created_at", type: "bigint", nullable: false),
                    updatedat = table.Column<long>(name: "updated_at", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_loan_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_loan_transaction_m_customer_customerId",
                        column: x => x.customerId,
                        principalTable: "m_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_loan_transaction_m_installment_type_installmentTypeId",
                        column: x => x.installmentTypeId,
                        principalTable: "m_installment_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_loan_transaction_m_loan_type_loanTypeId",
                        column: x => x.loanTypeId,
                        principalTable: "m_loan_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_transaction_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transactiondate = table.Column<long>(name: "transaction_date", type: "bigint", nullable: false),
                    nominal = table.Column<double>(type: "float", nullable: false),
                    LoanTransactionid = table.Column<int>(type: "int", nullable: false),
                    GuaranteePictureId = table.Column<int>(type: "int", nullable: false),
                    LoanStatus = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<long>(name: "created_date", type: "bigint", nullable: false),
                    updateddate = table.Column<long>(name: "updated_date", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_transaction_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_transaction_detail_t_guarantee_picture_GuaranteePictureId",
                        column: x => x.GuaranteePictureId,
                        principalTable: "t_guarantee_picture",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_transaction_detail_t_loan_transaction_LoanTransactionid",
                        column: x => x.LoanTransactionid,
                        principalTable: "t_loan_transaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_customer_ProfilePictureId",
                table: "m_customer",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_t_loan_documents_CustomerId",
                table: "t_loan_documents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_t_loan_transaction_customerId",
                table: "t_loan_transaction",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_t_loan_transaction_installmentTypeId",
                table: "t_loan_transaction",
                column: "installmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_loan_transaction_loanTypeId",
                table: "t_loan_transaction",
                column: "loanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_t_transaction_detail_GuaranteePictureId",
                table: "t_transaction_detail",
                column: "GuaranteePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_t_transaction_detail_LoanTransactionid",
                table: "t_transaction_detail",
                column: "LoanTransactionid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_loan_documents");

            migrationBuilder.DropTable(
                name: "t_transaction_detail");

            migrationBuilder.DropTable(
                name: "t_guarantee_picture");

            migrationBuilder.DropTable(
                name: "t_loan_transaction");

            migrationBuilder.DropTable(
                name: "m_customer");

            migrationBuilder.DropTable(
                name: "m_installment_type");

            migrationBuilder.DropTable(
                name: "m_loan_type");

            migrationBuilder.DropTable(
                name: "m_profile_picture");
        }
    }
}
