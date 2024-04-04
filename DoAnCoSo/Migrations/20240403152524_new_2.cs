using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnCoSo.Migrations
{
    /// <inheritdoc />
    public partial class new_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyenThucThiUserGroup_UsersGroups_QuyenThucThi",
                table: "QuyenThucThiUserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuyenThucThiUserGroup",
                table: "QuyenThucThiUserGroup");

            migrationBuilder.DropIndex(
                name: "IX_QuyenThucThiUserGroup_QuyenThucThiID",
                table: "QuyenThucThiUserGroup");

            migrationBuilder.RenameColumn(
                name: "QuyenThucThi",
                table: "QuyenThucThiUserGroup",
                newName: "UserGroupID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuyenThucThiUserGroup",
                table: "QuyenThucThiUserGroup",
                columns: new[] { "QuyenThucThiID", "UserGroupID" });

            migrationBuilder.CreateIndex(
                name: "IX_QuyenThucThiUserGroup_UserGroupID",
                table: "QuyenThucThiUserGroup",
                column: "UserGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyenThucThiUserGroup_UsersGroups_UserGroupID",
                table: "QuyenThucThiUserGroup",
                column: "UserGroupID",
                principalTable: "UsersGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyenThucThiUserGroup_UsersGroups_UserGroupID",
                table: "QuyenThucThiUserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuyenThucThiUserGroup",
                table: "QuyenThucThiUserGroup");

            migrationBuilder.DropIndex(
                name: "IX_QuyenThucThiUserGroup_UserGroupID",
                table: "QuyenThucThiUserGroup");

            migrationBuilder.RenameColumn(
                name: "UserGroupID",
                table: "QuyenThucThiUserGroup",
                newName: "QuyenThucThi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuyenThucThiUserGroup",
                table: "QuyenThucThiUserGroup",
                columns: new[] { "QuyenThucThi", "QuyenThucThiID" });

            migrationBuilder.CreateIndex(
                name: "IX_QuyenThucThiUserGroup_QuyenThucThiID",
                table: "QuyenThucThiUserGroup",
                column: "QuyenThucThiID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyenThucThiUserGroup_UsersGroups_QuyenThucThi",
                table: "QuyenThucThiUserGroup",
                column: "QuyenThucThi",
                principalTable: "UsersGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
