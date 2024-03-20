using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsuranceAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    AgencyCode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssueDate = table.Column<string>(type: "text", nullable: false),
                    VictimFullName = table.Column<string>(type: "text", nullable: false),
                    VictimPolicyNumber = table.Column<string>(type: "text", nullable: false),
                    VictimInsuranceID = table.Column<int>(type: "integer", nullable: false),
                    VictimCity = table.Column<int>(type: "integer", nullable: false),
                    VehicleMakerAndModel = table.Column<string>(type: "text", nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "text", nullable: false),
                    VehicleType = table.Column<string>(type: "text", nullable: false),
                    VehicleSeriesNumber = table.Column<string>(type: "text", nullable: false),
                    VehicleGenre = table.Column<string>(type: "text", nullable: false),
                    VehicleWeight = table.Column<int>(type: "integer", nullable: false),
                    AtFaultFullName = table.Column<string>(type: "text", nullable: true),
                    AtFaultPolicyNumber = table.Column<string>(type: "text", nullable: true),
                    AtFaultCity = table.Column<int>(type: "integer", nullable: true),
                    AtFaultInsuranceID = table.Column<int>(type: "integer", nullable: true),
                    AssociatedExpertID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Expert_AssociatedExpertID",
                        column: x => x.AssociatedExpertID,
                        principalTable: "Expert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Insurance_AtFaultInsuranceID",
                        column: x => x.AtFaultInsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceOrder_Insurance_VictimInsuranceID",
                        column: x => x.VictimInsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertiseReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    Incident = table.Column<string>(type: "text", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VehicleConditionBeforeIncident = table.Column<string>(type: "text", nullable: false),
                    ImpactPoint = table.Column<string>(type: "text", nullable: false),
                    DamagedPoint = table.Column<string>(type: "text", nullable: false),
                    PaintAndAdditions = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    LaborDescription = table.Column<string>(type: "text", nullable: false),
                    LaborCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ServiceOrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertiseReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertiseReport_ServiceOrder_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DamagedPart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartName = table.Column<string>(type: "text", nullable: true),
                    PartPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Reduction = table.Column<int>(type: "integer", nullable: false),
                    ExpertiseReportID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamagedPart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamagedPart_ExpertiseReport_ExpertiseReportID",
                        column: x => x.ExpertiseReportID,
                        principalTable: "ExpertiseReport",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DamagedPart_ExpertiseReportID",
                table: "DamagedPart",
                column: "ExpertiseReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertiseReport_ServiceOrderId",
                table: "ExpertiseReport",
                column: "ServiceOrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_AssociatedExpertID",
                table: "ServiceOrder",
                column: "AssociatedExpertID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_AtFaultInsuranceID",
                table: "ServiceOrder",
                column: "AtFaultInsuranceID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_VictimInsuranceID",
                table: "ServiceOrder",
                column: "VictimInsuranceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamagedPart");

            migrationBuilder.DropTable(
                name: "ExpertiseReport");

            migrationBuilder.DropTable(
                name: "ServiceOrder");

            migrationBuilder.DropTable(
                name: "Expert");

            migrationBuilder.DropTable(
                name: "Insurance");
        }
    }
}
