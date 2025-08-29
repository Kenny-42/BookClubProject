using BookClub.Data;
using BookClub.Repositories;
using BookClub.Resources;
using BookClub.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BookClub.Forms;

public partial class Reviews : Form
{
    private AccountsRepository _repo;
    private BookRepository _bookRepo;
    private UserContext _userContext;
    private BookContext _bookContext;
    private Book _book;

    private PictureBox[] stars;
    private int currentRating = 0;

    public Reviews(UserContext userContext, AccountsRepository repo, BookRepository bookRepo, BookContext bookContext)
    {
        InitializeComponent();

        _repo = repo;
        _bookRepo = bookRepo;
        _userContext = userContext;
        _bookContext = bookContext;

        _book = _bookContext.CurrentBook;

        this.FormClosed += (s, args) => Application.Exit();

        LoadBookInfo();

        stars = new PictureBox[] { pcbStar1, pcbStar2, pcbStar3, pcbStar4, pcbStar5 };
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].Tag = i + 1;
            stars[i].Image = Properties.Resources.star_empty;
            stars[i].Cursor = Cursors.Hand;
            stars[i].Click += Star_Click;
        }
    }

    private void Star_Click(object sender, EventArgs e)
    {
        PictureBox clickedStar = sender as PictureBox;
        int rating = (int)clickedStar.Tag;
        currentRating = rating;
        UpdateStarImages(rating);
    }

    private void UpdateStarImages(int rating)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < rating)
            {
                stars[i].Image = Properties.Resources.star_filled;
            }
            else
            {
                stars[i].Image = Properties.Resources.star_empty;
            }
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        var loginForm = Program.AppServices.GetRequiredService<Login>();
        loginForm.Show();
        this.Hide();
    }

    private void btnBookList_Click(object sender, EventArgs e)
    {
        BookList bookListForm = Program.AppServices.GetRequiredService<BookList>();
        bookListForm.Show();
        this.Hide();
    }

    private void btnOpenDiscussionBoard_Click(object sender, EventArgs e)
    {
        DiscussionBoard discussionBoardForm = Program.AppServices.GetRequiredService<DiscussionBoard>();
        discussionBoardForm.Show();
        this.Hide();
    }

    private void LoadBookInfo()
    {
        if (_book != null)
        {
            lblBookTitle.Text = _book.Title;
            lblAuthor.Text = "Author: " + _book.Author;
            lblISBN.Text = "ISBN: " + _book.ISBN;
            lblDescription.Text = _book.Description;
        }
        else
        {
            lblBookTitle.Text = "Book Title";
            lblAuthor.Text = "Author";
            lblISBN.Text = "ISBN";
            lblDescription.Text = "Description";
        }
    }
}
