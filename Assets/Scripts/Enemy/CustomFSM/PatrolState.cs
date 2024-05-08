
using System.Data;

public class PatrolState : BaseState
{
    private EnemyFSM enemyFSM;

    public PatrolState(EnemyFSM stateMachine) : base("patrol", stateMachine)
    {
        enemyFSM = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
 
        patrolAgent.Destination = patrolPoints.GetNext();
    }

    public override void Update()
    {
        base.Update();

        var patrolAgent = stateMachine.GetComponent<PatrollingAgent>();
        var patrolPoints = stateMachine.GetComponent<PatrolPoints>();
        
        if (patrolPoints.HasReached(patrolAgent))
            patrolAgent.Destination = patrolPoints.GetNext();
        
        var sightSensor = stateMachine.GetComponent<EnemySightSensor>();
        if (sightSensor.Ping())
        {
            stateMachine.ChangeState(enemyFSM.chaseState);
        }
    }
}