import style from "../../styles/athlete-main-page.module.css";
import TrainerDashboardView from "../../components/trainer/dashboard/trainer-dashboard-view";
import TrainerSidebar from "../../components/trainer/sidebar";
import {getSession} from "next-auth/react";

export async function getServerSideProps(context) {
    const session = await getSession({ req: context.req });

    if (!session) {
        return {
            redirect: {
                destination: "/auth/login",
                permanent: false,
            },
        };
    }
    return {
        props: {jwt: session.jwt},
    };
}

const TrainerDashboard = () => {
  return (
    <div className={style.container}>
      <div style={{ borderRight: "1px solid #D0D5DD", width: "325px" }}>
        <TrainerSidebar />
      </div>
      <TrainerDashboardView />
    </div>
  );
};

export default TrainerDashboard;
