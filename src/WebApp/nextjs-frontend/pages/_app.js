import "../styles/globals.css";
import "bootstrap/dist/css/bootstrap.css";

import Head from "next/head";
import { SessionProvider } from "next-auth/react";

import { ToastContainer } from "react-toastify";

function MyApp({ Component, pageProps: { session, ...pageProps } }) {
  const Layout = Component.layout || (({ children }) => <>{children}</>);
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
        <Layout>
          <Component {...pageProps} />;
          <ToastContainer />
        </Layout>
      </SessionProvider>
    </>
  );
}

export default MyApp;
