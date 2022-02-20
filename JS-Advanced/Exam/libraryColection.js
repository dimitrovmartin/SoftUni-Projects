class LibraryCollection{
    constructor(capacity){
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor){
        if (this.books.length == this.capacity){
            throw Error('Not enough space in the collection.');
        }

        this.books.push({
            bookName,
            bookAuthor,
            payed: false
        });

        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName){
        let book = this.books.find(e => e.bookName == bookName);

        if (!book){
            throw Error(`${bookName} is not in the collection.`);
        }

        if (book.payed){
            throw Error(`${bookName} has already been paid.`);
        }

        book.payed = true;

        return `${bookName} has been successfully paid.`
    }

    removeBook(bookName){
        let book = this.books.find(e => e.bookName == bookName);

        if (!book){
            throw Error(`The book, you're looking for, is not found.`);
        }

        if (!book.payed){
            throw Error(`${bookName} need to be paid before removing from the collection.`);
        }

        let index = this.books.indexOf(book);
        
        this.books.splice(index, 1);

        return `${bookName} remove from the collection.`
    }

    getStatistics(bookAuthor){
        let result = [];

        if (bookAuthor){
            let booksByAuthor = this.books.filter(b => b.bookAuthor == bookAuthor);
            
            if (booksByAuthor.length == 0){
                throw Error(`${bookAuthor} is not in the collection.`)
            }

            for (const book of booksByAuthor) {
                let payedStatus = '';

                if (book.payed){
                    payedStatus = 'Has Paid';
                } else{
                    payedStatus = 'Not Paid'
                }

                result.push(`${book.bookName} == ${book.bookAuthor} - ${payedStatus}.`)
            }
            
        } else{
            result.push(`The book collection has ${this.capacity - this.books.length} empty spots left.`);

            for (const book of this.books.sort((a, b) => a.bookName.localeCompare(b.bookName))) {
                let payedStatus = '';

                if (book.payed){
                    payedStatus = 'Has Paid';
                } else{
                    payedStatus = 'Not Paid'
                }

                result.push(`${book.bookName} == ${book.bookAuthor} - ${payedStatus}.`)
            }
        }

        return result.join('\n');
    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());
