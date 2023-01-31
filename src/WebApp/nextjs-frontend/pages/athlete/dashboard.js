import { getSession, useSession } from "next-auth/react";
import DashboardMain from "../../components/athlete-view/athlete-dashboard/dashboard-main";
import Athlete from "../../components/layouts/Athlete";
import fetcher from "../../lib/rest-api";

export async function getServerSideProps(context) {
  const session = await getSession({ req: context.req });

  if (!session) {
    return {
      redirect: {
        destination: "/auth/login",
        pernament: false,
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
