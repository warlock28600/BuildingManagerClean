using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeType",
                columns: table => new
                {
                    AttributeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeTypeTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeType", x => x.AttributeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Compounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPeriod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", maxLength: 8, nullable: false),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Mobile = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.AttributeId);
                    table.ForeignKey(
                        name: "FK_Attribute_AttributeType_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeType",
                        principalColumn: "AttributeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(24)", maxLength: 24, nullable: false),
                    BuildingAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    BuildingNumber = table.Column<string>(type: "varchar(10)", nullable: false),
                    CompoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_Compounds_CompoundId",
                        column: x => x.CompoundId,
                        principalTable: "Compounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "User"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    FinancialPeriodId = table.Column<int>(type: "int", nullable: false),
                    CostTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpanseType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_Attribute_CostTypeId",
                        column: x => x.CostTypeId,
                        principalTable: "Attribute",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_FinancialPeriod_FinancialPeriodId",
                        column: x => x.FinancialPeriodId,
                        principalTable: "FinancialPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitEntity",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    UnitNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UnitTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UnitArea = table.Column<int>(type: "int", nullable: false),
                    ExtraParkingCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitEntity", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_UnitEntity_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidentEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    MoveInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoveOutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResidentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: true),
                    UnitEntityUnitId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentEntity_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentEntity_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ResidentEntity_UnitEntity_UnitEntityUnitId",
                        column: x => x.UnitEntityUnitId,
                        principalTable: "UnitEntity",
                        principalColumn: "UnitId");
                    table.ForeignKey(
                        name: "FK_ResidentEntity_UnitEntity_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitEntity",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitExpense_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitExpense_UnitEntity_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitEntity",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitOwner",
                columns: table => new
                {
                    UnitOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    OwnerShipPercent = table.Column<double>(type: "float", nullable: true),
                    HouseholdCount = table.Column<int>(type: "int", nullable: false),
                    ExtraParkingCount = table.Column<int>(type: "int", nullable: false),
                    unitArea = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOwner", x => x.UnitOwnerId);
                    table.ForeignKey(
                        name: "FK_UnitOwner_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitOwner_UnitEntity_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitEntity",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_AttributeTypeId",
                table: "Attribute",
                column: "AttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_CompoundId",
                table: "Building",
                column: "CompoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_CostTypeId",
                table: "Expense",
                column: "CostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_FinancialPeriodId",
                table: "Expense",
                column: "FinancialPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentEntity_PersonId_UnitId",
                table: "ResidentEntity",
                columns: new[] { "PersonId", "UnitId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidentEntity_PersonsId",
                table: "ResidentEntity",
                column: "PersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentEntity_UnitEntityUnitId",
                table: "ResidentEntity",
                column: "UnitEntityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentEntity_UnitId",
                table: "ResidentEntity",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitEntity_BuildingId",
                table: "UnitEntity",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitExpense_ExpenseId",
                table: "UnitExpense",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitExpense_UnitId",
                table: "UnitExpense",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOwner_PersonId",
                table: "UnitOwner",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOwner_UnitId",
                table: "UnitOwner",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResidentEntity");

            migrationBuilder.DropTable(
                name: "UnitExpense");

            migrationBuilder.DropTable(
                name: "UnitOwner");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "UnitEntity");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "FinancialPeriod");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.DropTable(
                name: "AttributeType");

            migrationBuilder.DropTable(
                name: "Compounds");
        }
    }
}
