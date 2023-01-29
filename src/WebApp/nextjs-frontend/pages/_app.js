import "../styles/globals.css";
import "bootstrap/dist/css/bootstrap.css";
import Head from "next/head";

import { SessionProvider } from "next-auth/react";
import { useFetchUser } from "../lib/authContext";

function MyApp({ Component, pageProps: { session, ...pageProps } }) {
  const Layout = Component.layout || (({ children }) => <>{children}</>);
  var user = useFetchUser;
  return (
    <>
      <Head>
        <title>BodyGuard</title>
        <meta
          name='description'
          content='BodyGuard app meant for all fitness enthusiasts'
        />
        <link rel='icon' href='/favicon.ico' />
      </Head>
      <SessionProvider session={session}>
        <Layout user={user}>
          <Component {...pageProps} />;
        </Layout>
      </SessionProvider>
    </>
  );
}

export default MyApp;
