import React from "react";
import DefaultLeftPane from "../reusable-comps/default-left-pane";
import { UserProvider } from "../../lib/authContext";
import style from "../../styles/athlete-main-page.module.css";

function Athlete({ user, loading = false, children }) {
  return (
    <UserProvider value={{ user, loading }}>
      <div className={style.container}>
        <div style={{ borderRight: "1px solid #D0D5DD", width: "350px" }}>
          <DefaultLeftPane />
        </div>
        {children}
      </div>
    </UserProvider>
  );
}

export default Athlete;
