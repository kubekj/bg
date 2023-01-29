import Image from "next/image";
import styles from "../styles/Home.module.css";
import Link from "next/link";
import logo from "../public/logo.png";

import Athlete from "../components/layouts/Athlete";

export default function Home() {
  return (
    <div className={styles.container}>
      <main className={styles.main}>
        <h1 className={styles.title}>
          <Link href='/auth/login'>Log in</Link>
          <br />
          <Link href='/auth/signin'>Sign in</Link>
          <br />
          <Link href='/athlete/dashboard'>Go to athlete main page</Link>
        </h1>
      </main>
    </div>
  );
}
