import Router from "next/router";
import Cookies from "js-cookie";
import fetcher from "./rest-api";

export const setToken = (data) => {
  if (typeof window === "undefined") {
    return;
  }

  Cookies.set("id", data.id);
  Cookies.set("email", data.email);
  Cookies.set("jwt", data.jwt);

  if (Cookies.get("email")) {
    Router.push("/");
  }
};

export const unsetToken = () => {
  if (typeof window === "undefined") {
    return;
  }

  Cookies.remove("id");
  Cookies.remove("jwt");
  Cookies.remove("email");

  Router.push("/login");
};

export const getUserFromLocalCookie = () => {
  const jwt = getTokenFromLocalCookie();
  if (jwt) {
    return fetcher(`users/details`, {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${jwt}`,
      },
    })
      .then((data) => {
        return data.email;
      })
      .catch((error) => console.error(error));
  } else {
    return;
  }
};

export const getIdFromLocalCookie = () => {
  const jwt = getTokenFromLocalCookie();
  if (jwt) {
    return fetcher(`users/details`, {
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${jwt}`,
      },
    }).then((data) => {
      return data.id;
    });
  } else {
    return;
  }
};

export const getTokenFromLocalCookie = () => {
  return Cookies.get("jwt") || null;
};

export const getTokenFromServerCookie = (req) => {
  if (!req.headers.cookie || "") {
    return undefined;
  }
  const jwtCookie = req.headers.cookie
    .split(";")
    .find((c) => c.trim().startsWith("jwt="));
  if (!jwtCookie) {
    return undefined;
  }
  const jwt = jwtCookie.split("=")[1];
  return jwt;
};

export const getIdFromServerCookie = (req) => {
  if (!req.headers.cookie || "") {
    return undefined;
  }
  const idCookie = req.headers.cookie
    .split(";")
    .find((c) => c.trim().startsWith("id="));
  if (!idCookie) {
    return undefined;
  }
  const id = idCookie.split("=")[1];
  return id;
};
