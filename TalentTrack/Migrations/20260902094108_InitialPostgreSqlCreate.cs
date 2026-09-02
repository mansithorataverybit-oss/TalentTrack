using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalentTrack.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgreSqlCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "candidates",
                columns: table => new
                {
                    candidate_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    skills = table.Column<string>(type: "text", nullable: true),
                    experience = table.Column<int>(type: "integer", nullable: true),
                    resume = table.Column<string>(type: "text", nullable: true),
                    reset_otp = table.Column<string>(type: "text", nullable: true),
                    reset_otp_expiry = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidates", x => x.candidate_id);
                });

            migrationBuilder.CreateTable(
                name: "interviewers",
                columns: table => new
                {
                    interviewer_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    department = table.Column<string>(type: "text", nullable: true),
                    specialization = table.Column<string>(type: "text", nullable: true),
                    linked_in = table.Column<string>(type: "text", nullable: true),
                    bio = table.Column<string>(type: "text", nullable: true),
                    years_experience = table.Column<int>(type: "integer", nullable: true),
                    avatar_initials = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interviewers", x => x.interviewer_id);
                });

            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    job_title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    skills = table.Column<string>(type: "text", nullable: false),
                    experience = table.Column<string>(type: "text", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_jobs", x => x.job_id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    target_role = table.Column<string>(type: "text", nullable: false),
                    target_user_email = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    message = table.Column<string>(type: "text", nullable: false),
                    is_read = table.Column<bool>(type: "boolean", nullable: false),
                    target_url = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notifications", x => x.notification_id);
                });

            migrationBuilder.CreateTable(
                name: "recruiters",
                columns: table => new
                {
                    recruiter_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    department = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    is_approved = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    reset_otp = table.Column<string>(type: "text", nullable: true),
                    reset_otp_expiry = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recruiters", x => x.recruiter_id);
                });

            migrationBuilder.CreateTable(
                name: "candidate_documents",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<int>(type: "integer", nullable: false),
                    document_type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    file_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    file_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_documents", x => x.document_id);
                    table.ForeignKey(
                        name: "fk_candidate_documents_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_skills",
                columns: table => new
                {
                    candidate_skill_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<int>(type: "integer", nullable: false),
                    skill_name = table.Column<string>(type: "text", nullable: false),
                    experience_years = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_skills", x => x.candidate_skill_id);
                    table.ForeignKey(
                        name: "fk_candidate_skills_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "candidate_applications",
                columns: table => new
                {
                    application_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<int>(type: "integer", nullable: false),
                    job_id = table.Column<int>(type: "integer", nullable: false),
                    applied_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    background_verification_status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_candidate_applications", x => x.application_id);
                    table.ForeignKey(
                        name: "fk_candidate_applications_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_candidate_applications_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "interviews",
                columns: table => new
                {
                    interview_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<int>(type: "integer", nullable: false),
                    job_id = table.Column<int>(type: "integer", nullable: true),
                    duration = table.Column<int>(type: "integer", nullable: false),
                    meeting_link = table.Column<string>(type: "text", nullable: true),
                    interview_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    mode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    notes = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interviews", x => x.interview_id);
                    table.ForeignKey(
                        name: "fk_interviews_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_interviews_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "job_skills",
                columns: table => new
                {
                    job_skill_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    job_id = table.Column<int>(type: "integer", nullable: false),
                    skill_name = table.Column<string>(type: "text", nullable: false),
                    required_experience = table.Column<int>(type: "integer", nullable: false),
                    source = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_job_skills", x => x.job_skill_id);
                    table.ForeignKey(
                        name: "fk_job_skills_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "job_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "offer_letters",
                columns: table => new
                {
                    offer_letter_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    candidate_id = table.Column<int>(type: "integer", nullable: false),
                    application_id = table.Column<int>(type: "integer", nullable: false),
                    joining_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    offer_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    file_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    file_path = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_offer_letters", x => x.offer_letter_id);
                    table.ForeignKey(
                        name: "fk_offer_letters_candidate_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "candidate_applications",
                        principalColumn: "application_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_offer_letters_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "screenings",
                columns: table => new
                {
                    screening_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    application_id = table.Column<int>(type: "integer", nullable: false),
                    screened_by_user_id = table.Column<int>(type: "integer", nullable: false),
                    screening_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_screenings", x => x.screening_id);
                    table.ForeignKey(
                        name: "fk_screenings_candidate_applications_application_id",
                        column: x => x.application_id,
                        principalTable: "candidate_applications",
                        principalColumn: "application_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interview_feedbacks",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    interview_id = table.Column<int>(type: "integer", nullable: false),
                    candidate_id = table.Column<int>(type: "integer", nullable: false),
                    interviewer_id = table.Column<int>(type: "integer", nullable: false),
                    overall_rating = table.Column<int>(type: "integer", nullable: false),
                    technical_score = table.Column<int>(type: "integer", nullable: false),
                    communication_score = table.Column<int>(type: "integer", nullable: false),
                    problem_solving_score = table.Column<int>(type: "integer", nullable: false),
                    strengths = table.Column<string>(type: "text", nullable: true),
                    weaknesses = table.Column<string>(type: "text", nullable: true),
                    comments = table.Column<string>(type: "text", nullable: true),
                    recommendation = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interview_feedbacks", x => x.feedback_id);
                    table.ForeignKey(
                        name: "fk_interview_feedbacks_candidates_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "candidates",
                        principalColumn: "candidate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_interview_feedbacks_interviewers_interviewer_id",
                        column: x => x.interviewer_id,
                        principalTable: "interviewers",
                        principalColumn: "interviewer_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_interview_feedbacks_interviews_interview_id",
                        column: x => x.interview_id,
                        principalTable: "interviews",
                        principalColumn: "interview_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interview_interviewers",
                columns: table => new
                {
                    interview_id = table.Column<int>(type: "integer", nullable: false),
                    interviewer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interview_interviewers", x => new { x.interview_id, x.interviewer_id });
                    table.ForeignKey(
                        name: "fk_interview_interviewers_interviewers_interviewer_id",
                        column: x => x.interviewer_id,
                        principalTable: "interviewers",
                        principalColumn: "interviewer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_interview_interviewers_interviews_interview_id",
                        column: x => x.interview_id,
                        principalTable: "interviews",
                        principalColumn: "interview_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interview_participants",
                columns: table => new
                {
                    interview_participant_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    interview_id = table.Column<int>(type: "integer", nullable: false),
                    recruiter_id = table.Column<int>(type: "integer", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_interview_participants", x => x.interview_participant_id);
                    table.ForeignKey(
                        name: "fk_interview_participants_interviews_interview_id",
                        column: x => x.interview_id,
                        principalTable: "interviews",
                        principalColumn: "interview_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_interview_participants_recruiters_recruiter_id",
                        column: x => x.recruiter_id,
                        principalTable: "recruiters",
                        principalColumn: "recruiter_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "screening_skill_evaluations",
                columns: table => new
                {
                    evaluation_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    screening_id = table.Column<int>(type: "integer", nullable: false),
                    skill_name = table.Column<string>(type: "text", nullable: false),
                    has_skill = table.Column<bool>(type: "boolean", nullable: false),
                    experience_years = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_screening_skill_evaluations", x => x.evaluation_id);
                    table.ForeignKey(
                        name: "fk_screening_skill_evaluations_screenings_screening_id",
                        column: x => x.screening_id,
                        principalTable: "screenings",
                        principalColumn: "screening_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedback_skill_ratings",
                columns: table => new
                {
                    feedback_skill_rating_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    feedback_id = table.Column<int>(type: "integer", nullable: false),
                    job_skill_id = table.Column<int>(type: "integer", nullable: true),
                    skill_name = table.Column<string>(type: "text", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_feedback_skill_ratings", x => x.feedback_skill_rating_id);
                    table.ForeignKey(
                        name: "fk_feedback_skill_ratings_interview_feedbacks_feedback_id",
                        column: x => x.feedback_id,
                        principalTable: "interview_feedbacks",
                        principalColumn: "feedback_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_feedback_skill_ratings_job_skills_job_skill_id",
                        column: x => x.job_skill_id,
                        principalTable: "job_skills",
                        principalColumn: "job_skill_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "interviewers",
                columns: new[] { "interviewer_id", "avatar_initials", "bio", "created_at", "department", "email", "linked_in", "name", "password", "phone", "specialization", "years_experience" },
                values: new object[] { 1, "PS", "Senior Software Engineer with 8+ years of experience.", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engineering", "interviewer@talenttrack.com", "linkedin.com/in/priyasharma", "Priya Sharma", "interviewer123", "+91 98765 43210", "Full Stack Development", 8 });

            migrationBuilder.InsertData(
                table: "recruiters",
                columns: new[] { "recruiter_id", "created_at", "created_by", "department", "email", "is_approved", "name", "password", "phone", "reset_otp", "reset_otp_expiry", "role", "status", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Administration", "admin@talenttrack.com", true, "System Admin", "admin123", "+91 99999 88888", null, null, "Admin", "Approved", null, null },
                    { 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Human Resources", "recruiter@talenttrack.com", true, "Mansi Verma", "recruiter123", "+91 98765 11111", null, null, "Recruiter", "Approved", null, null },
                    { 3, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", "Engineering", "interviewer@talenttrack.com", true, "Priya Sharma", "interviewer123", "+91 98765 43210", null, null, "Interviewer", "Approved", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_candidate_applications_candidate_id_job_id",
                table: "candidate_applications",
                columns: new[] { "candidate_id", "job_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_candidate_applications_job_id",
                table: "candidate_applications",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_documents_candidate_id",
                table: "candidate_documents",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_candidate_skills_candidate_id",
                table: "candidate_skills",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_feedback_skill_ratings_feedback_id",
                table: "feedback_skill_ratings",
                column: "feedback_id");

            migrationBuilder.CreateIndex(
                name: "ix_feedback_skill_ratings_job_skill_id",
                table: "feedback_skill_ratings",
                column: "job_skill_id");

            migrationBuilder.CreateIndex(
                name: "ix_interview_feedbacks_candidate_id",
                table: "interview_feedbacks",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_interview_feedbacks_interview_id",
                table: "interview_feedbacks",
                column: "interview_id");

            migrationBuilder.CreateIndex(
                name: "ix_interview_feedbacks_interviewer_id",
                table: "interview_feedbacks",
                column: "interviewer_id");

            migrationBuilder.CreateIndex(
                name: "ix_interview_interviewers_interviewer_id",
                table: "interview_interviewers",
                column: "interviewer_id");

            migrationBuilder.CreateIndex(
                name: "ix_interview_participants_interview_id_recruiter_id",
                table: "interview_participants",
                columns: new[] { "interview_id", "recruiter_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_interview_participants_recruiter_id",
                table: "interview_participants",
                column: "recruiter_id");

            migrationBuilder.CreateIndex(
                name: "ix_interviews_candidate_id",
                table: "interviews",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_interviews_job_id",
                table: "interviews",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_job_skills_job_id",
                table: "job_skills",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_letters_application_id",
                table: "offer_letters",
                column: "application_id");

            migrationBuilder.CreateIndex(
                name: "ix_offer_letters_candidate_id",
                table: "offer_letters",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "ix_screening_skill_evaluations_screening_id",
                table: "screening_skill_evaluations",
                column: "screening_id");

            migrationBuilder.CreateIndex(
                name: "ix_screenings_application_id",
                table: "screenings",
                column: "application_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidate_documents");

            migrationBuilder.DropTable(
                name: "candidate_skills");

            migrationBuilder.DropTable(
                name: "feedback_skill_ratings");

            migrationBuilder.DropTable(
                name: "interview_interviewers");

            migrationBuilder.DropTable(
                name: "interview_participants");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "offer_letters");

            migrationBuilder.DropTable(
                name: "screening_skill_evaluations");

            migrationBuilder.DropTable(
                name: "interview_feedbacks");

            migrationBuilder.DropTable(
                name: "job_skills");

            migrationBuilder.DropTable(
                name: "recruiters");

            migrationBuilder.DropTable(
                name: "screenings");

            migrationBuilder.DropTable(
                name: "interviewers");

            migrationBuilder.DropTable(
                name: "interviews");

            migrationBuilder.DropTable(
                name: "candidate_applications");

            migrationBuilder.DropTable(
                name: "candidates");

            migrationBuilder.DropTable(
                name: "jobs");
        }
    }
}
