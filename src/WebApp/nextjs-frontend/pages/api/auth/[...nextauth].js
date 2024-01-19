import NextAuth from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials";
import {signin} from "../../../lib/rest-api";

export const options = {
    providers: [
        CredentialsProvider({
            credentials: {
                email: {label: "Email", type: "email"},
                password: {label: "Password", type: "password"},
            },
            async authorize(credentials, req) {
                if (credentials == null) return null;
                const user = await signin(credentials);
                if (!user) return null;
                return user;
            },
        }),
    ],
    session: {
        strategy: "jwt",
        maxAge: 12 * 60 * 60,
    },
    callbacks: {
        jwt: async ({token, user}) => {
            const isSignIn = user ? true : false;
            if (isSignIn) {
                token.jwt = user.jwt;
                token.id = user.id;
                token.fullName = user.fullName;
                token.role = user.role;
            }
            return Promise.resolve(token);
        },
        session: async ({session, token}) => {
            session.jwt = token.jwt;
            session.id = token.id;
            session.user.fullName = token.fullName;
            session.user.role = token.role;
            return Promise.resolve(session);
        },
    },
};

const Auth = (req, res) => NextAuth(req, res, options);

export default Auth;
