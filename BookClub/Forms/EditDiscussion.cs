using BookClub.Models;
using BookClub.Repositories;
using BookClub.Resources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace BookClub.Forms
{
    public partial class EditDiscussion : Form
    {
        private readonly DiscussionsRepository _repo;
        private readonly Discussion? _selectedDiscussion = null;
        public EditDiscussion(DiscussionsRepository repo)
        {
            InitializeComponent();
            _repo = repo;

            var discussionContext = Program.AppServices.GetRequiredService<DiscussionContext>();
            _selectedDiscussion = discussionContext.CurrentDiscussion;
            txtComment.Text = discussionContext.CurrentDiscussion.Comment;
            this.FormClosed += (s, args) => Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = Program.AppServices.GetRequiredService<Login>();
            loginForm.Show();
            this.Hide();
        }

        private bool ValidateInput(string comment, out string error)
        {
            error = string.Empty;

            // Only validate non-blank fields
            // No validation needed for title or author since their only requirement is to be non-blank

            // Description cannot be longer than 1024 characters
            if (!string.IsNullOrEmpty(comment))
            {
                if (comment.Length > 2048)
                {
                    error = "Description cannot be longer than 2048 characters.";
                    return false;
                }
            }
            return true;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(txtComment.Text, out string error))
            {
                MessageBox.Show(error, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DiscussionUpdateDTO dto = new DiscussionUpdateDTO
            {
                Comment = txtComment.Text
            };

            var result = _repo.Update(_selectedDiscussion.Id, dto);
            if (!result)
            {
                MessageBox.Show("No changes found");
            }

            DiscussionBoard discussionBoard = Program.AppServices.GetRequiredService<DiscussionBoard>();
            discussionBoard.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DiscussionBoard discussionBoard = Program.AppServices.GetRequiredService<DiscussionBoard>();
            discussionBoard.Show();
            this.Hide();
        }
    }
}
