using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAnCoSo.Migrations
{
    /// <inheritdoc />
    public partial class int_dba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DienThoais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DienThoais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DSQuyenThucThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DSQuyenThucThi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NameGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpLungs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpLungID = table.Column<int>(type: "int", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    DienThoaiID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpLungs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpLungs_DienThoais_DienThoaiID",
                        column: x => x.DienThoaiID,
                        principalTable: "DienThoais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpLungs_DienThoais_OpLungID",
                        column: x => x.OpLungID,
                        principalTable: "DienThoais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuyenThucThiUserGroup",
                columns: table => new
                {
                    QuyenThucThiID = table.Column<int>(type: "int", nullable: false),
                    UserGroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenThucThiUserGroup", x => new { x.QuyenThucThiID, x.UserGroupID });
                    table.ForeignKey(
                        name: "FK_QuyenThucThiUserGroup_DSQuyenThucThi_QuyenThucThiID",
                        column: x => x.QuyenThucThiID,
                        principalTable: "DSQuyenThucThi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenThucThiUserGroup_UsersGroups_UserGroupID",
                        column: x => x.UserGroupID,
                        principalTable: "UsersGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserGroup",
                columns: table => new
                {
                    UserGroupID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserGroup", x => new { x.UserGroupID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserUserGroup_UsersGroups_UserGroupID",
                        column: x => x.UserGroupID,
                        principalTable: "UsersGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserGroup_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpLungs_DienThoaiID",
                table: "OpLungs",
                column: "DienThoaiID");

            migrationBuilder.CreateIndex(
                name: "IX_OpLungs_OpLungID",
                table: "OpLungs",
                column: "OpLungID");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenThucThiUserGroup_UserGroupID",
                table: "QuyenThucThiUserGroup",
                column: "UserGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserGroup_UserID",
                table: "UserUserGroup",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpLungs");

            migrationBuilder.DropTable(
                name: "QuyenThucThiUserGroup");

            migrationBuilder.DropTable(
                name: "UserUserGroup");

            migrationBuilder.DropTable(
                name: "DienThoais");

            migrationBuilder.DropTable(
                name: "DSQuyenThucThi");

            migrationBuilder.DropTable(
                name: "UsersGroups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
