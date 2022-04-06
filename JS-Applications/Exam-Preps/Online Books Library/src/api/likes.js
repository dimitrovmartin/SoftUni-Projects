import * as api from './api.js';


const endpoints = {
     likes: (id) => `/data/likes?where=bookId%3D%22${id}%22&distinct=_ownerId&count`,
     isLiked: (bookId, userId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
     like: `/data/likes`
};

export async function getLikesByBookId (id) {
    return api.get(endpoints.likes(id));
}

export async function isLiked (bookId, userId) {
    return api.get(endpoints.isLiked(bookId, userId));
}

export async function like (bookId) {
    return api.post(endpoints.like, {bookId});
}