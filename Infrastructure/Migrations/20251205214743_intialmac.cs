using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class intialmac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribute_AttributeType_AttributeTypeId",
                table: "Attribute");

            migrationBuilder.DropForeignKey(
                name: "FK_Building_Compounds_CompoundId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Attribute_CostTypeId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_FinancialPeriod_FinancialPeriodId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentEntity_Persons_PersonId",
                table: "ResidentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentEntity_Persons_PersonsId",
                table: "ResidentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentEntity_UnitEntity_UnitEntityUnitId",
                table: "ResidentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentEntity_UnitEntity_UnitId",
                table: "ResidentEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitEntity_Building_BuildingId",
                table: "UnitEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitExpense_Expense_ExpenseId",
                table: "UnitExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitExpense_UnitEntity_UnitId",
                table: "UnitExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOwner_Persons_PersonId",
                table: "UnitOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOwner_UnitEntity_UnitId",
                table: "UnitOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOwner",
                table: "UnitOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitEntity",
                table: "UnitEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentEntity",
                table: "ResidentEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialPeriod",
                table: "FinancialPeriod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeType",
                table: "AttributeType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute");

            migrationBuilder.RenameTable(
                name: "UnitOwner",
                newName: "UnitOwners");

            migrationBuilder.RenameTable(
                name: "UnitEntity",
                newName: "UnitEntities");

            migrationBuilder.RenameTable(
                name: "ResidentEntity",
                newName: "Residents");

            migrationBuilder.RenameTable(
                name: "FinancialPeriod",
                newName: "FinancialPeriods");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "BuildingEntities");

            migrationBuilder.RenameTable(
                name: "AttributeType",
                newName: "AttributeTypes");

            migrationBuilder.RenameTable(
                name: "Attribute",
                newName: "Attributes");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOwner_UnitId",
                table: "UnitOwners",
                newName: "IX_UnitOwners_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOwner_PersonId",
                table: "UnitOwners",
                newName: "IX_UnitOwners_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitEntity_BuildingId",
                table: "UnitEntities",
                newName: "IX_UnitEntities_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentEntity_UnitId",
                table: "Residents",
                newName: "IX_Residents_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentEntity_UnitEntityUnitId",
                table: "Residents",
                newName: "IX_Residents_UnitEntityUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentEntity_PersonsId",
                table: "Residents",
                newName: "IX_Residents_PersonsId");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentEntity_PersonId_UnitId",
                table: "Residents",
                newName: "IX_Residents_PersonId_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_FinancialPeriodId",
                table: "Expenses",
                newName: "IX_Expenses_FinancialPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_CostTypeId",
                table: "Expenses",
                newName: "IX_Expenses_CostTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Building_CompoundId",
                table: "BuildingEntities",
                newName: "IX_BuildingEntities_CompoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Attribute_AttributeTypeId",
                table: "Attributes",
                newName: "IX_Attributes_AttributeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOwners",
                table: "UnitOwners",
                column: "UnitOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitEntities",
                table: "UnitEntities",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residents",
                table: "Residents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialPeriods",
                table: "FinancialPeriods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingEntities",
                table: "BuildingEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeTypes",
                table: "AttributeTypes",
                column: "AttributeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_AttributeTypes_AttributeTypeId",
                table: "Attributes",
                column: "AttributeTypeId",
                principalTable: "AttributeTypes",
                principalColumn: "AttributeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingEntities_Compounds_CompoundId",
                table: "BuildingEntities",
                column: "CompoundId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Attributes_CostTypeId",
                table: "Expenses",
                column: "CostTypeId",
                principalTable: "Attributes",
                principalColumn: "AttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_FinancialPeriods_FinancialPeriodId",
                table: "Expenses",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Persons_PersonId",
                table: "Residents",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_Persons_PersonsId",
                table: "Residents",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_UnitEntities_UnitEntityUnitId",
                table: "Residents",
                column: "UnitEntityUnitId",
                principalTable: "UnitEntities",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_UnitEntities_UnitId",
                table: "Residents",
                column: "UnitId",
                principalTable: "UnitEntities",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitEntities_BuildingEntities_BuildingId",
                table: "UnitEntities",
                column: "BuildingId",
                principalTable: "BuildingEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitExpense_Expenses_ExpenseId",
                table: "UnitExpense",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitExpense_UnitEntities_UnitId",
                table: "UnitExpense",
                column: "UnitId",
                principalTable: "UnitEntities",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOwners_Persons_PersonId",
                table: "UnitOwners",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOwners_UnitEntities_UnitId",
                table: "UnitOwners",
                column: "UnitId",
                principalTable: "UnitEntities",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_AttributeTypes_AttributeTypeId",
                table: "Attributes");

            migrationBuilder.DropForeignKey(
                name: "FK_BuildingEntities_Compounds_CompoundId",
                table: "BuildingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Attributes_CostTypeId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_FinancialPeriods_FinancialPeriodId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Persons_PersonId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_Persons_PersonsId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_UnitEntities_UnitEntityUnitId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_Residents_UnitEntities_UnitId",
                table: "Residents");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitEntities_BuildingEntities_BuildingId",
                table: "UnitEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitExpense_Expenses_ExpenseId",
                table: "UnitExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitExpense_UnitEntities_UnitId",
                table: "UnitExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOwners_Persons_PersonId",
                table: "UnitOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOwners_UnitEntities_UnitId",
                table: "UnitOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitOwners",
                table: "UnitOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitEntities",
                table: "UnitEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residents",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialPeriods",
                table: "FinancialPeriods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingEntities",
                table: "BuildingEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeTypes",
                table: "AttributeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                table: "Attributes");

            migrationBuilder.RenameTable(
                name: "UnitOwners",
                newName: "UnitOwner");

            migrationBuilder.RenameTable(
                name: "UnitEntities",
                newName: "UnitEntity");

            migrationBuilder.RenameTable(
                name: "Residents",
                newName: "ResidentEntity");

            migrationBuilder.RenameTable(
                name: "FinancialPeriods",
                newName: "FinancialPeriod");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "BuildingEntities",
                newName: "Building");

            migrationBuilder.RenameTable(
                name: "AttributeTypes",
                newName: "AttributeType");

            migrationBuilder.RenameTable(
                name: "Attributes",
                newName: "Attribute");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOwners_UnitId",
                table: "UnitOwner",
                newName: "IX_UnitOwner_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitOwners_PersonId",
                table: "UnitOwner",
                newName: "IX_UnitOwner_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_UnitEntities_BuildingId",
                table: "UnitEntity",
                newName: "IX_UnitEntity_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_UnitId",
                table: "ResidentEntity",
                newName: "IX_ResidentEntity_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_UnitEntityUnitId",
                table: "ResidentEntity",
                newName: "IX_ResidentEntity_UnitEntityUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_PersonsId",
                table: "ResidentEntity",
                newName: "IX_ResidentEntity_PersonsId");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_PersonId_UnitId",
                table: "ResidentEntity",
                newName: "IX_ResidentEntity_PersonId_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_FinancialPeriodId",
                table: "Expense",
                newName: "IX_Expense_FinancialPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CostTypeId",
                table: "Expense",
                newName: "IX_Expense_CostTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_BuildingEntities_CompoundId",
                table: "Building",
                newName: "IX_Building_CompoundId");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_AttributeTypeId",
                table: "Attribute",
                newName: "IX_Attribute_AttributeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitOwner",
                table: "UnitOwner",
                column: "UnitOwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitEntity",
                table: "UnitEntity",
                column: "UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentEntity",
                table: "ResidentEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialPeriod",
                table: "FinancialPeriod",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeType",
                table: "AttributeType",
                column: "AttributeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribute_AttributeType_AttributeTypeId",
                table: "Attribute",
                column: "AttributeTypeId",
                principalTable: "AttributeType",
                principalColumn: "AttributeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Compounds_CompoundId",
                table: "Building",
                column: "CompoundId",
                principalTable: "Compounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Attribute_CostTypeId",
                table: "Expense",
                column: "CostTypeId",
                principalTable: "Attribute",
                principalColumn: "AttributeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_FinancialPeriod_FinancialPeriodId",
                table: "Expense",
                column: "FinancialPeriodId",
                principalTable: "FinancialPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentEntity_Persons_PersonId",
                table: "ResidentEntity",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentEntity_Persons_PersonsId",
                table: "ResidentEntity",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentEntity_UnitEntity_UnitEntityUnitId",
                table: "ResidentEntity",
                column: "UnitEntityUnitId",
                principalTable: "UnitEntity",
                principalColumn: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentEntity_UnitEntity_UnitId",
                table: "ResidentEntity",
                column: "UnitId",
                principalTable: "UnitEntity",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitEntity_Building_BuildingId",
                table: "UnitEntity",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitExpense_Expense_ExpenseId",
                table: "UnitExpense",
                column: "ExpenseId",
                principalTable: "Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitExpense_UnitEntity_UnitId",
                table: "UnitExpense",
                column: "UnitId",
                principalTable: "UnitEntity",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOwner_Persons_PersonId",
                table: "UnitOwner",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOwner_UnitEntity_UnitId",
                table: "UnitOwner",
                column: "UnitId",
                principalTable: "UnitEntity",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
