import DashboardMain from "../../../components/athlete/dashboard/dashboard-main";
import Athlete from "../../../components/layouts/Athlete";
import { getSession } from "next-auth/react";

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
    props: { jwt: session.jwt },
  };
}

const AthleteMainPage = ({ jwt }) => {
  return <DashboardMain />;
};

export default AthleteMainPage;

AthleteMainPage.layout = Athlete;
